using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;

namespace CI
{
    public static class RefreshAssets
    {
        public static void Run()
        {
            var packageSource = GetRequiredArgument("-packageSource");
            var publishRoot = GetRequiredArgument("-publishRoot");

            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);

            var localPackages = UnityEditor.PackageManager.PackageInfo
                .GetAllRegisteredPackages()
                .Where(p => p.source == UnityEditor.PackageManager.PackageSource.Local
                            || p.source == UnityEditor.PackageManager.PackageSource.Embedded)
                .ToArray();

            foreach (var package in localPackages)
            {
                ForceImportAllFolders(package.assetPath, package.resolvedPath);
            }

            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);
            AssetDatabase.SaveAssets();

            PublishPackage(packageSource, publishRoot);
        }

        private static void ForceImportAllFolders(string packageAssetPath, string packageResolvedPath)
        {
            if (string.IsNullOrWhiteSpace(packageAssetPath) || string.IsNullOrWhiteSpace(packageResolvedPath))
            {
                return;
            }

            var root = Path.GetFullPath(packageResolvedPath);
            if (!Directory.Exists(root))
            {
                return;
            }

            AssetDatabase.ImportAsset(packageAssetPath, ImportAssetOptions.ForceSynchronousImport | ImportAssetOptions.ForceUpdate);

            foreach (var directory in Directory.GetDirectories(root, "*", SearchOption.AllDirectories))
            {
                var relative = directory.Substring(root.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                if (string.IsNullOrEmpty(relative))
                {
                    continue;
                }

                var assetPath = packageAssetPath + "/" + relative.Replace('\\', '/');
                AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceSynchronousImport | ImportAssetOptions.ForceUpdate);
            }
        }

        private static string GetRequiredArgument(string argumentName)
        {
            var args = Environment.GetCommandLineArgs();
            for (var i = 0; i < args.Length - 1; i++)
            {
                if (string.Equals(args[i], argumentName, StringComparison.OrdinalIgnoreCase))
                {
                    return args[i + 1];
                }
            }

            throw new InvalidOperationException("Missing required command line argument: " + argumentName);
        }

        private static void PublishPackage(string packageSource, string publishRoot)
        {
            var sourceRoot = Path.GetFullPath(packageSource);
            var outputRoot = Path.GetFullPath(publishRoot);

            if (!Directory.Exists(sourceRoot))
            {
                throw new DirectoryNotFoundException("Package source directory not found: " + sourceRoot);
            }

            var packageJsonPath = Path.Combine(sourceRoot, "package.json");
            if (!File.Exists(packageJsonPath))
            {
                throw new FileNotFoundException("Package source is missing package.json", packageJsonPath);
            }

            if (Directory.Exists(outputRoot))
            {
                Directory.Delete(outputRoot, true);
            }

            Directory.CreateDirectory(outputRoot);
            CopyDirectory(sourceRoot, outputRoot, new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                ".git",
                ".github"
            });
        }

        private static void CopyDirectory(string sourceRoot, string destinationRoot, HashSet<string> excludedNames)
        {
            foreach (var directory in Directory.GetDirectories(sourceRoot, "*", SearchOption.AllDirectories))
            {
                var relativePath = Path.GetRelativePath(sourceRoot, directory);
                if (ShouldSkip(relativePath, excludedNames))
                {
                    continue;
                }

                Directory.CreateDirectory(Path.Combine(destinationRoot, relativePath));
            }

            foreach (var filePath in Directory.GetFiles(sourceRoot, "*", SearchOption.AllDirectories))
            {
                var relativePath = Path.GetRelativePath(sourceRoot, filePath);
                if (ShouldSkip(relativePath, excludedNames))
                {
                    continue;
                }

                var destinationPath = Path.Combine(destinationRoot, relativePath);
                var destinationDirectory = Path.GetDirectoryName(destinationPath);
                if (!string.IsNullOrEmpty(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                File.Copy(filePath, destinationPath, true);
            }
        }

        private static bool ShouldSkip(string relativePath, HashSet<string> excludedNames)
        {
            var segments = relativePath
                .Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);

            return segments.Any(excludedNames.Contains);
        }
    }
}

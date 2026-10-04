using System;
using System.Runtime.InteropServices;
using System.Text;

public static class NNG
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Socket
    {
        private uint id;

        public bool IsValid => id != 0;
    }

    public const int FLAG_ALLOC = 1;
    public const int FLAG_NONBLOCK = 2;
    private const int MAX_MESSAGE_BYTES = 64 * 1024 * 1024;

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    private const string NNG_LIB = "nng.dll";
#elif UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    private const string NNG_LIB = "libnng.dylib";
#elif UNITY_EDITOR_LINUX || UNITY_STANDALONE_LINUX
    private const string NNG_LIB = "libnng.so";
#else
    private const string NNG_LIB = "nng";
#endif

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_close(Socket socket);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_req0_open(out Socket socket);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_rep0_open(out Socket socket);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_sub0_open(out Socket socket);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_pub0_open(out Socket socket);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_pair0_open(out Socket socket);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_pair1_open(out Socket socket);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_socket_set(Socket socket, string opt, IntPtr val, UIntPtr valsz);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_socket_set_string(Socket socket, string opt, string val);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_socket_set_ms(Socket socket, string opt, int milliseconds);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_listen(Socket socket, string url, IntPtr listener, int flags);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_dial(Socket socket, string url, IntPtr dialer, int flags);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_send(Socket socket, IntPtr data, UIntPtr size, int flags);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_recv(Socket socket, ref IntPtr data, ref UIntPtr size, int flags);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void nng_free(IntPtr data, UIntPtr size);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr nng_strerror(int error);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_sendmsg(Socket socket, IntPtr msg, int flags);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_recvmsg(Socket socket, out IntPtr msg, int flags);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_msg_alloc(out IntPtr msg, UIntPtr size);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int nng_msg_append(IntPtr msg, IntPtr val, UIntPtr size);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void nng_msg_clear(IntPtr msg);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr nng_msg_body(IntPtr msg);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern UIntPtr nng_msg_len(IntPtr msg);

    [DllImport(NNG_LIB, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void nng_msg_free(IntPtr msg);

    public static int SendUtf8(Socket socket, string value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));

        byte[] bytes = Encoding.UTF8.GetBytes(value);
        GCHandle pin = default;
        try
        {
            IntPtr pointer = IntPtr.Zero;
            if (bytes.Length != 0)
            {
                pin = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                pointer = pin.AddrOfPinnedObject();
            }
            return nng_send(socket, pointer, new UIntPtr((uint)bytes.Length), 0);
        }
        finally
        {
            if (pin.IsAllocated) pin.Free();
        }
    }

    public static int ReceiveUtf8(Socket socket, out string value)
    {
        IntPtr allocated = IntPtr.Zero;
        UIntPtr length = UIntPtr.Zero;
        int status = nng_recv(socket, ref allocated, ref length, FLAG_ALLOC);
        if (status != 0)
        {
            value = null;
            return status;
        }

        try
        {
            ulong count = length.ToUInt64();
            if ((allocated == IntPtr.Zero && count != 0) || count > MAX_MESSAGE_BYTES)
                throw new InvalidOperationException("NNG returned an invalid message buffer.");

            byte[] bytes = new byte[(int)count];
            if (bytes.Length != 0) Marshal.Copy(allocated, bytes, 0, bytes.Length);
            value = Encoding.UTF8.GetString(bytes);
            return 0;
        }
        finally
        {
            if (allocated != IntPtr.Zero) nng_free(allocated, length);
        }
    }

    public static string GetErrorText(int error)
    {
        IntPtr text = nng_strerror(error);
        return text == IntPtr.Zero ? "unknown NNG error" : Marshal.PtrToStringAnsi(text);
    }

    public static string GetMessageUtf8(IntPtr msg)
    {
        ulong length = nng_msg_len(msg).ToUInt64();
        if (length > int.MaxValue)
        {
            throw new InvalidOperationException($"NNG message is too large: {length} bytes.");
        }

        if (length == 0)
        {
            return string.Empty;
        }

        var bytes = new byte[(int)length];
        Marshal.Copy(nng_msg_body(msg), bytes, 0, bytes.Length);
        return Encoding.UTF8.GetString(bytes);
    }
}

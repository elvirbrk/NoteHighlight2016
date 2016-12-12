/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace NoteHighlightAddin.Utilities
{
    class CCOMStreamWrapper : IStream
    {
        public CCOMStreamWrapper(System.IO.Stream streamWrap)
        {
            m_stream = streamWrap;
        }

        public void Clone(out IStream ppstm)
        {
            ppstm = new CCOMStreamWrapper(m_stream);
        }

        public void Commit(int grfCommitFlags)
        {
            m_stream.Flush();
        }

        public void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
        {
        }

        public void LockRegion(long libOffset, long cb, int dwLockType)
        {
            throw new System.NotImplementedException();
        }

        public void Read(byte[] pv, int cb, IntPtr pcbRead)
        {
            Marshal.WriteInt64(pcbRead, m_stream.Read(pv, 0, cb));
        }

        public void Revert()
        {
            throw new System.NotImplementedException();
        }

        public void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
        {
            long posMoveTo = 0;
            Marshal.WriteInt64(plibNewPosition, m_stream.Position);
            switch (dwOrigin)
            {
                case 0:
                    {
                        /* STREAM_SEEK_SET */
                        posMoveTo = dlibMove;
                    }
                    break;
                case 1:
                    {
                        /* STREAM_SEEK_CUR */
                        posMoveTo = m_stream.Position + dlibMove;

                    }
                    break;
                case 2:
                    {
                        /* STREAM_SEEK_END */
                        posMoveTo = m_stream.Length + dlibMove;
                    }
                    break;
                default:
                    return;
            }
            if (posMoveTo >= 0 && posMoveTo < m_stream.Length)
            {
                m_stream.Position = posMoveTo;
                Marshal.WriteInt64(plibNewPosition, m_stream.Position);
            }
        }

        public void SetSize(long libNewSize)
        {
            m_stream.SetLength(libNewSize);
        }

        public void Stat(out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg, int grfStatFlag)
        {
            pstatstg = new System.Runtime.InteropServices.ComTypes.STATSTG();
            pstatstg.cbSize = m_stream.Length;
            if ((grfStatFlag & 0x0001/* STATFLAG_NONAME */) != 0)
                return;
            pstatstg.pwcsName = m_stream.ToString();
        }

        public void UnlockRegion(long libOffset, long cb, int dwLockType)
        {
            throw new System.NotImplementedException();
        }

        public void Write(byte[] pv, int cb, IntPtr pcbWritten)
        {
            Marshal.WriteInt64(pcbWritten, 0);
            m_stream.Write(pv, 0, cb);
            Marshal.WriteInt64(pcbWritten, cb);
        }

        private System.IO.Stream m_stream;
    }
}
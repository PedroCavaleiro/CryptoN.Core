﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoN
{
    public class IV
    {
        private byte[] _underlyingBytes;

        public int LengthInBits
        {
            get
            {
                return _underlyingBytes.Length * 8;
            }
        }

        public IV(byte[] ivAsBytes)
        {
            if(null == ivAsBytes || ivAsBytes.Length == 0)
            {
                throw new ArgumentNullException(nameof(ivAsBytes));
            }

            var validIv = Validate(ivAsBytes);

            if(!validIv)
            {
                throw new ArgumentException("IV should only be a multiple of 32 (bits) and between 128 and 256 bits long", nameof(ivAsBytes));
            }

            _underlyingBytes = ivAsBytes;
        }

        private bool Validate(byte[] ivAsBytes)
        {
            var ivBitLength = ivAsBytes.Length * 8;

            var valid = (128 <= ivBitLength && ivBitLength <= 256) &&
                            ivBitLength % 32 == 0;

            return valid;
        }

        public byte[] GetBytes()
        {
            return _underlyingBytes;
        }

        public override string ToString()
        { 
            return _underlyingBytes.ToHexString();
        }
    }
}

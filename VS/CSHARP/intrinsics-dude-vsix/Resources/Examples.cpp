
#include <cstring> //for memset
#include <stdio.h>
#include <stdlib.h>
#include "immintrin.h"


namespace tools {



	int _mm512_extract_epi32(const __m512i a, int pos)
	{
		_mm_haddd_epi16()
		const __mmask16 k = _mm512_int2mask(1 << pos);
		return _mm512_mask_reduce_and_epi32(k, a);
	}

	__m512i _mm512_insert_epi32(__m512i a, int i, int pos)
	{
		__declspec(aligned(64)) int c[16];
		_mm512_store_si512(&c, a);
		c[pos] = i;
		return _mm512_load_epi32(&c);
	}

	unsigned __int64 _mm512_countbits_(const __m512i a)
	{
		unsigned __int64 nBits = 0;
		for (int j = 0; j < 8; ++j) {
			__mmask16 k = _mm512_int2mask(1 << j);
			nBits += _mm_countbits_64(_mm512_mask_reduce_or_epi64(k, a));
		}
		return nBits;
	}
}

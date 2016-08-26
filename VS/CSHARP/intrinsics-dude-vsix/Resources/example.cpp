//Intrinsics Dude Example

//#inlcude "intrin.h"  // declarations/definitions for platform specific intrinsic functions.
//#include "mmintrin.h"  // mmx
//#include "emmintrin.h"  // sse
//#include "pmmintrin.h"  // sse3
//#include "tmmintrin.h"  // ssse3
//#include "smmintrin.h"  // sse4.1
//#include "nmmintrin.h"  // sse4.2
#include "immintrin.h"  // avx, avx2, avx512, FP16C, KNCNI, FMA
//#include "ammintrin.h"  // AMD specific intrinsics


void main() {

	for (int i = 0; i < 100; ++i) {
		printf("test");

		/*
		const __m128 x1 = _m_packsswb(y1, y2); // bug no syntax highlighting code remarks
		const __m512d x = _mm512_atan_pd(x); // svml
		*/
		_mm

		//BUG: code completion does not work for non intrinsics

		const __m256d x2 = _mm25


		// SIGNATURE HELP: OK;
		// existing intrinsic functions:
		const __m256 a2 = _mm256_hadd_pd(a, b);     //"immintrin.h"
		const __m256 a3 = _mm256_abs_epi16(a);      //"immintrin.h"

		const __m128 a = _mm_addsub_pd(a, b);       //"pmmintrin.h"
		const __m128d a = _mm_set1_epi16(a);        //"emmintrin.h"
		
		// new intrinsic functions:
		const __m256i a1 _mm256_bslli_epi128(a, 10);                  //"immintrin.h"
		const __m256 a4 = _mm256_abs_epi64(a);                        //"immintrin.h"
		const __m512 bla6 = _mm512_andnot_si512(_mm512_abs_pd(a), b); //"immintrin.h"

		// SIGNATURE HELP: NOK: replacing the comma does not select the correct parameter
		const __m256i = _MM_INSERT_EPI16(a, b, 10);     //"emmintrin.h"
		const __m512 bla5 = _mm512_addn_round_ps(a, b, _MM_FROUND_TO_NEG_INF); //"immintrin.h"
	}

	return 0;
}

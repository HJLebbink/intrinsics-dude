//Intrinsics Dude Example

#include "pmmintrin.h"
#include "immintrin.h"

void main() {

	for (int i = 0; i < 100; ++i) {
		printf("test");

		// SIGNATURE HELP: OK;

		const __m128d a2 = _mm_hadd_pd(a, b);
		const __m256 a3 = _mm256_abs_epi16(a);
		const __m128d a = _mm_set1_epi16(a);

		// SIGNATURE HELP: NOK;

		__m256i a1 _mm256_bslli_epi128(a, b);
		__m256 a4 = _mm256_abs_epi64(a);
		__m512 bla5 = _mm512_addn_round_ps(a, b, _MM_FROUND_TO_NEG_INF);

		__m512 bla6 = _mm512_andnot_si512(_mm512_abs_pd(a), b);
	}

	return 0;
}

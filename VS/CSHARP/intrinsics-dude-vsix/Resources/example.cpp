//Intrinsics Dude Example

#include "pmmintrin.h"
#include "immintrin.h"


void main() {


	for (int i = 0; i < 100; ++i) {
		printf("test");

		const __m128d a = _mm_set1_epi16(10);
		const __m128d b = _mm_set1_epi16(20);

		__m128d bla = _mm_hadd_pd()
		__m256 bla2 = _mm256_abs_epi16(a);
		__m256 bla3 = _mm256_abs_epi64()
		__m256 bla4 = _mm256_abs_epi16(x, );


			_mm512_addn_round_ps(x, , 5);
	}


	return 0;
}

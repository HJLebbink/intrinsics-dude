//Intrinsics Dude Example

#include "pmmintrin.h"



void main() {


	for (int i = 0; i < 100; ++i) {
		printf("test");

		const __m128d a = _mm_set1(10);
		const __m128d b = _mm_set1(20);

		__m128d bla = _mm_hadd_pd(a, b);

	}


	return 0;
}

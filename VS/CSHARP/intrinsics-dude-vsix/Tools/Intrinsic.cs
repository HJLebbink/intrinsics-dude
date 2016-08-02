// The MIT License (MIT)
//
// Copyright (c) 2016 Henk-Jan Lebbink
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace IntrinsicsDude.Tools
{
    public enum Intrinsic
    {
        NONE,

        ///<summary>Compute the absolute value of packed 16-bit integers in a, and store the unsigned results in dst. (SSSE3)</summary>
        _MM_ABS_EPI16,
        ///<summary>Compute the absolute value of packed 16-bit integers in a, and store the unsigned results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_ABS_EPI16,
        ///<summary>Compute the absolute value of packed 16-bit integers in a, and store the unsigned results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_ABS_EPI16,
        ///<summary>Compute the absolute value of packed 16-bit integers in a, and store the unsigned results in dst. (AVX2)</summary>
        _MM256_ABS_EPI16,
        ///<summary>Compute the absolute value of packed 16-bit integers in a, and store the unsigned results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_ABS_EPI16,
        ///<summary>Compute the absolute value of packed 16-bit integers in a, and store the unsigned results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_ABS_EPI16,
        ///<summary>Compute the absolute value of packed 16-bit integers in a, and store the unsigned results in dst. (AVX512BW)</summary>
        _MM512_ABS_EPI16,
        ///<summary>Compute the absolute value of packed 16-bit integers in a, and store the unsigned results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_ABS_EPI16,
        ///<summary>Compute the absolute value of packed 16-bit integers in a, and store the unsigned results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_ABS_EPI16,
        ///<summary>Compute the absolute value of packed 32-bit integers in a, and store the unsigned results in dst. (SSSE3)</summary>
        _MM_ABS_EPI32,
        ///<summary>Compute the absolute value of packed 32-bit integers in a, and store the unsigned results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_ABS_EPI32,
        ///<summary>Compute the absolute value of packed 32-bit integers in a, and store the unsigned results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_ABS_EPI32,
        ///<summary>Compute the absolute value of packed 32-bit integers in a, and store the unsigned results in dst. (AVX2)</summary>
        _MM256_ABS_EPI32,
        ///<summary>Compute the absolute value of packed 32-bit integers in a, and store the unsigned results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_ABS_EPI32,
        ///<summary>Compute the absolute value of packed 32-bit integers in a, and store the unsigned results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_ABS_EPI32,
        ///<summary>Compute the absolute value of packed 32-bit integers in a, and store the unsigned results in dst. (AVX512F)</summary>
        _MM512_ABS_EPI32,
        ///<summary>Compute the absolute value of packed 32-bit integers in a, and store the unsigned results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ABS_EPI32,
        ///<summary>Compute the absolute value of packed 32-bit integers in a, and store the unsigned results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_ABS_EPI32,
        ///<summary>Compute the absolute value of packed 64-bit integers in a, and store the unsigned results in dst. (AVX512VL, AVX512F)</summary>
        _MM_ABS_EPI64,
        ///<summary>Compute the absolute value of packed 64-bit integers in a, and store the unsigned results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_ABS_EPI64,
        ///<summary>Compute the absolute value of packed 64-bit integers in a, and store the unsigned results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_ABS_EPI64,
        ///<summary>Compute the absolute value of packed 64-bit integers in a, and store the unsigned results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_ABS_EPI64,
        ///<summary>Compute the absolute value of packed 64-bit integers in a, and store the unsigned results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_ABS_EPI64,
        ///<summary>Compute the absolute value of packed 64-bit integers in a, and store the unsigned results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_ABS_EPI64,
        ///<summary>Compute the absolute value of packed 64-bit integers in a, and store the unsigned results in dst. (AVX512F)</summary>
        _MM512_ABS_EPI64,
        ///<summary>Compute the absolute value of packed 64-bit integers in a, and store the unsigned results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ABS_EPI64,
        ///<summary>Compute the absolute value of packed 64-bit integers in a, and store the unsigned results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_ABS_EPI64,
        ///<summary>Compute the absolute value of packed 8-bit integers in a, and store the unsigned results in dst. (SSSE3)</summary>
        _MM_ABS_EPI8,
        ///<summary>Compute the absolute value of packed 8-bit integers in a, and store the unsigned results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_ABS_EPI8,
        ///<summary>Compute the absolute value of packed 8-bit integers in a, and store the unsigned results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_ABS_EPI8,
        ///<summary>Compute the absolute value of packed 8-bit integers in a, and store the unsigned results in dst. (AVX2)</summary>
        _MM256_ABS_EPI8,
        ///<summary>Compute the absolute value of packed 8-bit integers in a, and store the unsigned results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_ABS_EPI8,
        ///<summary>Compute the absolute value of packed 8-bit integers in a, and store the unsigned results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_ABS_EPI8,
        ///<summary>Compute the absolute value of packed 8-bit integers in a, and store the unsigned results in dst. (AVX512BW)</summary>
        _MM512_ABS_EPI8,
        ///<summary>Compute the absolute value of packed 8-bit integers in a, and store the unsigned results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_ABS_EPI8,
        ///<summary>Compute the absolute value of packed 8-bit integers in a, and store the unsigned results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_ABS_EPI8,
        ///<summary>Finds the absolute value of each packed double-precision (64-bit) floating-point element in v2, storing the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_ABS_PD,
        ///<summary>Finds the absolute value of each packed double-precision (64-bit) floating-point element in v2, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_ABS_PD,
        ///<summary>Compute the absolute value of packed 16-bit integers in a, and store the unsigned results in dst. (SSSE3)</summary>
        _MM_ABS_PI16,
        ///<summary>Compute the absolute value of packed 32-bit integers in a, and store the unsigned results in dst. (SSSE3)</summary>
        _MM_ABS_PI32,
        ///<summary>Compute the absolute value of packed 8-bit integers in a, and store the unsigned results in dst. (SSSE3)</summary>
        _MM_ABS_PI8,
        ///<summary>Finds the absolute value of each packed single-precision (32-bit) floating-point element in v2, storing the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_ABS_PS,
        ///<summary>Finds the absolute value of each packed single-precision (32-bit) floating-point element in v2, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_ABS_PS,
        ///<summary>Compute the inverse cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_ACOS_PD,
        ///<summary>Compute the inverse cosine of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_ACOS_PD,
        ///<summary>Compute the inverse cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX512F)</summary>
        _MM512_ACOS_PD,
        ///<summary>Compute the inverse cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ACOS_PD,
        ///<summary>Compute the inverse cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_ACOS_PS,
        ///<summary>Compute the inverse cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_ACOS_PS,
        ///<summary>Compute the inverse cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX512F)</summary>
        _MM512_ACOS_PS,
        ///<summary>Compute the inverse cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ACOS_PS,
        ///<summary>Compute the inverse hyperbolic cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_ACOSH_PD,
        ///<summary>Compute the inverse hyperbolic cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_ACOSH_PD,
        ///<summary>Compute the inverse hyperbolic cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX512F)</summary>
        _MM512_ACOSH_PD,
        ///<summary>Compute the inverse hyperbolic cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ACOSH_PD,
        ///<summary>Compute the inverse hyperbolic cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_ACOSH_PS,
        ///<summary>Compute the inverse hyperbolic cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_ACOSH_PS,
        ///<summary>Compute the inverse hyperbolic cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX512F)</summary>
        _MM512_ACOSH_PS,
        ///<summary>Compute the inverse hyperbolic cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ACOSH_PS,
        ///<summary>Performs element-by-element addition of packed 32-bit integers in v2 and v3 and the corresponding bit in k2, storing the result of the addition in dst and the result of the carry in k2_res. (KNCNI)</summary>
        _MM512_ADC_EPI32,
        ///<summary>Performs element-by-element addition of packed 32-bit integers in v2 and v3 and the corresponding bit in k2, storing the result of the addition in dst and the result of the carry in k2_res using writemask k1 (elements are copied from v2 when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_ADC_EPI32,
        ///<summary>Add packed 16-bit integers in a and b, and store the results in dst. (SSE2)</summary>
        _MM_ADD_EPI16,
        ///<summary>Add packed 16-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_ADD_EPI16,
        ///<summary>Add packed 16-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_ADD_EPI16,
        ///<summary>Add packed 16-bit integers in a and b, and store the results in dst. (AVX2)</summary>
        _MM256_ADD_EPI16,
        ///<summary>Add packed 16-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_ADD_EPI16,
        ///<summary>Add packed 16-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_ADD_EPI16,
        ///<summary>Add packed 16-bit integers in a and b, and store the results in dst. (AVX512BW)</summary>
        _MM512_ADD_EPI16,
        ///<summary>Add packed 16-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_ADD_EPI16,
        ///<summary>Add packed 16-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_ADD_EPI16,
        ///<summary>Add packed 32-bit integers in a and b, and store the results in dst. (SSE2)</summary>
        _MM_ADD_EPI32,
        ///<summary>Add packed 32-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_ADD_EPI32,
        ///<summary>Add packed 32-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_ADD_EPI32,
        ///<summary>Add packed 32-bit integers in a and b, and store the results in dst. (AVX2)</summary>
        _MM256_ADD_EPI32,
        ///<summary>Add packed 32-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_ADD_EPI32,
        ///<summary>Add packed 32-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_ADD_EPI32,
        ///<summary>Add packed 32-bit integers in a and b, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_ADD_EPI32,
        ///<summary>Add packed 32-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_ADD_EPI32,
        ///<summary>Add packed 32-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_ADD_EPI32,
        ///<summary>Add packed 64-bit integers in a and b, and store the results in dst. (SSE2)</summary>
        _MM_ADD_EPI64,
        ///<summary>Add packed 64-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_ADD_EPI64,
        ///<summary>Add packed 64-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_ADD_EPI64,
        ///<summary>Add packed 64-bit integers in a and b, and store the results in dst. (AVX2)</summary>
        _MM256_ADD_EPI64,
        ///<summary>Add packed 64-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_ADD_EPI64,
        ///<summary>Add packed 64-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_ADD_EPI64,
        ///<summary>Add packed 64-bit integers in a and b, and store the results in dst. (AVX512F)</summary>
        _MM512_ADD_EPI64,
        ///<summary>Add packed 64-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ADD_EPI64,
        ///<summary>Add packed 64-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_ADD_EPI64,
        ///<summary>Add packed 8-bit integers in a and b, and store the results in dst. (SSE2)</summary>
        _MM_ADD_EPI8,
        ///<summary>Add packed 8-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_ADD_EPI8,
        ///<summary>Add packed 8-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_ADD_EPI8,
        ///<summary>Add packed 8-bit integers in a and b, and store the results in dst. (AVX2)</summary>
        _MM256_ADD_EPI8,
        ///<summary>Add packed 8-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_ADD_EPI8,
        ///<summary>Add packed 8-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_ADD_EPI8,
        ///<summary>Add packed 8-bit integers in a and b, and store the results in dst. (AVX512BW)</summary>
        _MM512_ADD_EPI8,
        ///<summary>Add packed 8-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_ADD_EPI8,
        ///<summary>Add packed 8-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_ADD_EPI8,
        ///<summary>Add packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst. (SSE2)</summary>
        _MM_ADD_PD,
        ///<summary>Add packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM_MASK_ADD_PD,
        ///<summary>Add packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM_MASKZ_ADD_PD,
        ///<summary>Add packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst. (AVX)</summary>
        _MM256_ADD_PD,
        ///<summary>Add packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM256_MASK_ADD_PD,
        ///<summary>Add packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM256_MASKZ_ADD_PD,
        ///<summary>Add packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_ADD_PD,
        ///<summary>Add packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_ADD_PD,
        ///<summary>Add packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_ADD_PD,
        ///<summary>Add packed 16-bit integers in a and b, and store the results in dst. (MMX)</summary>
        _MM_ADD_PI16,
        ///<summary>Add packed 32-bit integers in a and b, and store the results in dst. (MMX)</summary>
        _MM_ADD_PI32,
        ///<summary>Add packed 8-bit integers in a and b, and store the results in dst. (MMX)</summary>
        _MM_ADD_PI8,
        ///<summary>Add packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst. (SSE)</summary>
        _MM_ADD_PS,
        ///<summary>Add packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM_MASK_ADD_PS,
        ///<summary>Add packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM_MASKZ_ADD_PS,
        ///<summary>Add packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst. (AVX)</summary>
        _MM256_ADD_PS,
        ///<summary>Add packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM256_MASK_ADD_PS,
        ///<summary>Add packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM256_MASKZ_ADD_PS,
        ///<summary>Add packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_ADD_PS,
        ///<summary>Add packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_ADD_PS,
        ///<summary>Add packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_ADD_PS,
        ///<summary>Add packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_ADD_ROUND_PD,
        ///<summary>Add packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK_ADD_ROUND_PD,
        ///<summary>Add packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_ADD_ROUND_PD,
        ///<summary>Add packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_ADD_ROUND_PS,
        ///<summary>Add packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK_ADD_ROUND_PS,
        ///<summary>Add packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_ADD_ROUND_PS,
        ///<summary>Add the lower double-precision (64-bit) floating-point element in a and b, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_ADD_ROUND_SD,
        ///<summary>Add the lower double-precision (64-bit) floating-point element in a and b, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 		Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_ADD_ROUND_SD,
        ///<summary>Add the lower double-precision (64-bit) floating-point element in a and b, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 		Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_ADD_ROUND_SD,
        ///<summary>Add the lower single-precision (32-bit) floating-point element in a and b, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. 		Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_ADD_ROUND_SS,
        ///<summary>Add the lower single-precision (32-bit) floating-point element in a and b, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst.  		Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_ADD_ROUND_SS,
        ///<summary>Add the lower single-precision (32-bit) floating-point element in a and b, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_ADD_ROUND_SS,
        ///<summary>Add the lower double-precision (64-bit) floating-point element in a and b, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_ADD_SD,
        ///<summary>Add the lower double-precision (64-bit) floating-point element in a and b, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASK_ADD_SD,
        ///<summary>Add the lower double-precision (64-bit) floating-point element in a and b, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASKZ_ADD_SD,
        ///<summary>Add 64-bit integers a and b, and store the result in dst. (SSE2)</summary>
        _MM_ADD_SI64,
        ///<summary>Add the lower single-precision (32-bit) floating-point element in a and b, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_ADD_SS,
        ///<summary>Add the lower single-precision (32-bit) floating-point element in a and b, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASK_ADD_SS,
        ///<summary>Add the lower single-precision (32-bit) floating-point element in a and b, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASKZ_ADD_SS,
        ///<summary>Add unsigned 32-bit integers a and b with unsigned 8-bit carry-in c_in (carry flag), and store the unsigned 32-bit result in out, and the carry-out in dst (carry or overflow flag). ()</summary>
        _ADDCARRY_U32,
        ///<summary>Add unsigned 64-bit integers a and b with unsigned 8-bit carry-in c_in (carry flag), and store the unsigned 64-bit result in out, and the carry-out in dst (carry or overflow flag). ()</summary>
        _ADDCARRY_U64,
        ///<summary>Add unsigned 32-bit integers a and b with unsigned 8-bit carry-in c_in (carry or overflow flag), and store the unsigned 32-bit result in out, and the carry-out in dst (carry or overflow flag). (ADX)</summary>
        _ADDCARRYX_U32,
        ///<summary>Add unsigned 64-bit integers a and b with unsigned 8-bit carry-in c_in (carry or overflow flag), and store the unsigned 64-bit result in out, and the carry-out in dst (carry or overflow flag). (ADX)</summary>
        _ADDCARRYX_U64,
        ///<summary>Performs element-by-element addition between packed double-precision (64-bit) floating-point elements in v2 and v3 and negates their sum, storing the results in dst. (KNCNI)</summary>
        _MM512_ADDN_PD,
        ///<summary>Performs element-by-element addition between packed double-precision (64-bit) floating-point elements in v2 and v3 and negates their sum, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_ADDN_PD,
        ///<summary>Performs element-by-element addition between packed single-precision (32-bit) floating-point elements in v2 and v3 and negates their sum, storing the results in dst. (KNCNI)</summary>
        _MM512_ADDN_PS,
        ///<summary>Performs element-by-element addition between packed single-precision (32-bit) floating-point elements in v2 and v3 and negates their sum, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_ADDN_PS,
        ///<summary>Performs element by element addition between packed double-precision (64-bit) floating-point elements in v2 and v3 and negates the sum, storing the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_ADDN_ROUND_PD,
        ///<summary>Performs element by element addition between packed double-precision (64-bit) floating-point elements in v2 and v3 and negates the sum, storing the result in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_MASK_ADDN_ROUND_PD,
        ///<summary>Performs element by element addition between packed single-precision (32-bit) floating-point elements in v2 and v3 and negates the sum, storing the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_ADDN_ROUND_PS,
        ///<summary>Performs element by element addition between packed single-precision (32-bit) floating-point elements in v2 and v3 and negates the sum, storing the result in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_MASK_ADDN_ROUND_PS,
        ///<summary>Add packed 16-bit integers in a and b using saturation, and store the results in dst. (SSE2)</summary>
        _MM_ADDS_EPI16,
        ///<summary>Add packed 16-bit integers in a and b using saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_ADDS_EPI16,
        ///<summary>Add packed 16-bit integers in a and b using saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_ADDS_EPI16,
        ///<summary>Add packed 16-bit integers in a and b using saturation, and store the results in dst. (AVX2)</summary>
        _MM256_ADDS_EPI16,
        ///<summary>Add packed 16-bit integers in a and b using saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_ADDS_EPI16,
        ///<summary>Add packed 16-bit integers in a and b using saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_ADDS_EPI16,
        ///<summary>Add packed 16-bit integers in a and b using saturation, and store the results in dst. (AVX512BW)</summary>
        _MM512_ADDS_EPI16,
        ///<summary>Add packed 16-bit integers in a and b using saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_ADDS_EPI16,
        ///<summary>Add packed 16-bit integers in a and b using saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_ADDS_EPI16,
        ///<summary>Add packed 8-bit integers in a and b using saturation, and store the results in dst. (SSE2)</summary>
        _MM_ADDS_EPI8,
        ///<summary>Add packed 8-bit integers in a and b using saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_ADDS_EPI8,
        ///<summary>Add packed 8-bit integers in a and b using saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_ADDS_EPI8,
        ///<summary>Add packed 8-bit integers in a and b using saturation, and store the results in dst. (AVX2)</summary>
        _MM256_ADDS_EPI8,
        ///<summary>Add packed 8-bit integers in a and b using saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_ADDS_EPI8,
        ///<summary>Add packed 8-bit integers in a and b using saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_ADDS_EPI8,
        ///<summary>Add packed 8-bit integers in a and b using saturation, and store the results in dst. (AVX512BW)</summary>
        _MM512_ADDS_EPI8,
        ///<summary>Add packed 8-bit integers in a and b using saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_ADDS_EPI8,
        ///<summary>Add packed 8-bit integers in a and b using saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_ADDS_EPI8,
        ///<summary>Add packed unsigned 16-bit integers in a and b using saturation, and store the results in dst. (SSE2)</summary>
        _MM_ADDS_EPU16,
        ///<summary>Add packed unsigned 16-bit integers in a and b using saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_ADDS_EPU16,
        ///<summary>Add packed unsigned 16-bit integers in a and b using saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_ADDS_EPU16,
        ///<summary>Add packed unsigned 16-bit integers in a and b using saturation, and store the results in dst. (AVX2)</summary>
        _MM256_ADDS_EPU16,
        ///<summary>Add packed unsigned 16-bit integers in a and b using saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_ADDS_EPU16,
        ///<summary>Add packed unsigned 16-bit integers in a and b using saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_ADDS_EPU16,
        ///<summary>Add packed unsigned 16-bit integers in a and b using saturation, and store the results in dst. (AVX512BW)</summary>
        _MM512_ADDS_EPU16,
        ///<summary>Add packed unsigned 16-bit integers in a and b using saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_ADDS_EPU16,
        ///<summary>Add packed unsigned 16-bit integers in a and b using saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_ADDS_EPU16,
        ///<summary>Add packed unsigned 8-bit integers in a and b using saturation, and store the results in dst. (SSE2)</summary>
        _MM_ADDS_EPU8,
        ///<summary>Add packed unsigned 8-bit integers in a and b using saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_ADDS_EPU8,
        ///<summary>Add packed unsigned 8-bit integers in a and b using saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_ADDS_EPU8,
        ///<summary>Add packed unsigned 8-bit integers in a and b using saturation, and store the results in dst. (AVX2)</summary>
        _MM256_ADDS_EPU8,
        ///<summary>Add packed unsigned 8-bit integers in a and b using saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_ADDS_EPU8,
        ///<summary>Add packed unsigned 8-bit integers in a and b using saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_ADDS_EPU8,
        ///<summary>Add packed unsigned 8-bit integers in a and b using saturation, and store the results in dst. (AVX512BW)</summary>
        _MM512_ADDS_EPU8,
        ///<summary>Add packed unsigned 8-bit integers in a and b using saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_ADDS_EPU8,
        ///<summary>Add packed unsigned 8-bit integers in a and b using saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_ADDS_EPU8,
        ///<summary>Add packed 16-bit integers in a and b using saturation, and store the results in dst. (MMX)</summary>
        _MM_ADDS_PI16,
        ///<summary>Add packed 8-bit integers in a and b using saturation, and store the results in dst. (MMX)</summary>
        _MM_ADDS_PI8,
        ///<summary>Add packed unsigned 16-bit integers in a and b using saturation, and store the results in dst. (MMX)</summary>
        _MM_ADDS_PU16,
        ///<summary>Add packed unsigned 8-bit integers in a and b using saturation, and store the results in dst. (MMX)</summary>
        _MM_ADDS_PU8,
        ///<summary>Performs element-by-element addition of packed 32-bit integer elements in v2 and v3, storing the resultant carry in k2_res (carry flag) and the addition results in dst. (KNCNI)</summary>
        _MM512_ADDSETC_EPI32,
        ///<summary>Performs element-by-element addition of packed 32-bit integer elements in v2 and v3, storing the resultant carry in k2_res (carry flag) and the addition results in dst using writemask k (elements are copied from v2 and k_old when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_ADDSETC_EPI32,
        ///<summary>Performs an element-by-element addition of packed 32-bit integer elements in v2 and v3, storing the results in dst and the sign of the sum in sign (sign flag). (KNCNI)</summary>
        _MM512_ADDSETS_EPI32,
        ///<summary>Performs an element-by-element addition of packed 32-bit integer elements in v2 and v3, storing the results in dst and the sign of the sum in sign (sign flag). Results are stored using writemask k (elements are copied from src when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_ADDSETS_EPI32,
        ///<summary>Performs an element-by-element addition of packed single-precision (32-bit) floating-point elements in v2 and v3, storing the results in dst and the sign of the sum in sign (sign flag). (KNCNI)</summary>
        _MM512_ADDSETS_PS,
        ///<summary>Performs an element-by-element addition of packed single-precision (32-bit) floating-point elements in v2 and v3, storing the results in dst and the sign of the sum in sign (sign flag). Results are stored using writemask k (elements are copied from src when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_ADDSETS_PS,
        ///<summary>Performs an element-by-element addition of packed single-precision (32-bit) floating-point elements in v2 and v3, storing the results in dst and the sign of the sum in sign (sign flag). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_ADDSETS_ROUND_PS,
        ///<summary>Performs an element-by-element addition of packed single-precision (32-bit) floating-point elements in v2 and v3, storing the results in dst and the sign of the sum in sign (sign flag). Results are stored using writemask k (elements are copied from src when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_MASK_ADDSETS_ROUND_PS,
        ///<summary>Alternatively add and subtract packed double-precision (64-bit) floating-point elements in a to/from packed elements in b, and store the results in dst. (SSE3)</summary>
        _MM_ADDSUB_PD,
        ///<summary>Alternatively add and subtract packed double-precision (64-bit) floating-point elements in a to/from packed elements in b, and store the results in dst. (AVX)</summary>
        _MM256_ADDSUB_PD,
        ///<summary>Alternatively add and subtract packed single-precision (32-bit) floating-point elements in a to/from packed elements in b, and store the results in dst. (SSE3)</summary>
        _MM_ADDSUB_PS,
        ///<summary>Alternatively add and subtract packed single-precision (32-bit) floating-point elements in a to/from packed elements in b, and store the results in dst. (AVX)</summary>
        _MM256_ADDSUB_PS,
        ///<summary>Perform one round of an AES decryption flow on data (state) in a using the round key in RoundKey, and store the result in dst." (AES)</summary>
        _MM_AESDEC_SI128,
        ///<summary>Perform the last round of an AES decryption flow on data (state) in a using the round key in RoundKey, and store the result in dst." (AES)</summary>
        _MM_AESDECLAST_SI128,
        ///<summary>Perform one round of an AES encryption flow on data (state) in a using the round key in RoundKey, and store the result in dst." (AES)</summary>
        _MM_AESENC_SI128,
        ///<summary>Perform the last round of an AES encryption flow on data (state) in a using the round key in RoundKey, and store the result in dst." (AES)</summary>
        _MM_AESENCLAST_SI128,
        ///<summary>Perform the InvMixColumns transformation on a and store the result in dst. (AES)</summary>
        _MM_AESIMC_SI128,
        ///<summary>Assist in expanding the AES cipher key by computing steps towards generating a round key for encryption cipher using data from a and an 8-bit round constant specified in imm8, and store the result in dst." (AES)</summary>
        _MM_AESKEYGENASSIST_SI128,
        ///<summary>Concatenate a and b into a 32-byte immediate result, shift the result right by count 32-bit elements, and store the low 16 bytes (4 elements) in dst. (AVX512F, AVX512VL)</summary>
        _MM_ALIGNR_EPI32,
        ///<summary>Concatenate a and b into a 32-byte immediate result, shift the result right by count 32-bit elements, and store the low 16 bytes (4 elements) in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM_MASK_ALIGNR_EPI32,
        ///<summary>Concatenate a and b into a 32-byte immediate result, shift the result right by count 32-bit elements, and store the low 16 bytes (4 elements) in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM_MASKZ_ALIGNR_EPI32,
        ///<summary>Concatenate a and b into a 64-byte immediate result, shift the result right by count 32-bit elements, and store the low 32 bytes (8 elements) in dst. (AVX512F, AVX512VL)</summary>
        _MM256_ALIGNR_EPI32,
        ///<summary>Concatenate a and b into a 64-byte immediate result, shift the result right by count 32-bit elements, and store the low 32 bytes (8 elements) in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM256_MASK_ALIGNR_EPI32,
        ///<summary>Concatenate a and b into a 64-byte immediate result, shift the result right by count 32-bit elements, and store the low 32 bytes (8 elements) in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM256_MASKZ_ALIGNR_EPI32,
        ///<summary>Concatenate a and b into a 128-byte immediate result, shift the result right by count 32-bit elements, and store the low 64 bytes (16 elements) in dst. (AVX512F, KNCNI)</summary>
        _MM512_ALIGNR_EPI32,
        ///<summary>Concatenate a and b into a 128-byte immediate result, shift the result right by count 32-bit elements, and store the low 64 bytes (16 elements) in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_ALIGNR_EPI32,
        ///<summary>Concatenate a and b into a 128-byte immediate result, shift the result right by count 32-bit elements, and stores the low 64 bytes (16 elements) in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_ALIGNR_EPI32,
        ///<summary>Concatenate a and b into a 32-byte immediate result, shift the result right by count 64-bit elements, and store the low 16 bytes (2 elements) in dst. (AVX512F, AVX512VL)</summary>
        _MM_ALIGNR_EPI64,
        ///<summary>Concatenate a and b into a 32-byte immediate result, shift the result right by count 64-bit elements, and store the low 16 bytes (2 elements) in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM_MASK_ALIGNR_EPI64,
        ///<summary>Concatenate a and b into a 32-byte immediate result, shift the result right by count 64-bit elements, and store the low 16 bytes (2 elements) in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM_MASKZ_ALIGNR_EPI64,
        ///<summary>Concatenate a and b into a 64-byte immediate result, shift the result right by count 64-bit elements, and store the low 32 bytes (4 elements) in dst. (AVX512F, AVX512VL)</summary>
        _MM256_ALIGNR_EPI64,
        ///<summary>Concatenate a and b into a 64-byte immediate result, shift the result right by count 64-bit elements, and store the low 32 bytes (4 elements) in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM256_MASK_ALIGNR_EPI64,
        ///<summary>Concatenate a and b into a 64-byte immediate result, shift the result right by count 64-bit elements, and store the low 32 bytes (4 elements) in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, AVX512VL)</summary>
        _MM256_MASKZ_ALIGNR_EPI64,
        ///<summary>Concatenate a and b into a 128-byte immediate result, shift the result right by count 64-bit elements, and store the low 64 bytes (8 elements) in dst. (AVX512F)</summary>
        _MM512_ALIGNR_EPI64,
        ///<summary>Concatenate a and b into a 128-byte immediate result, shift the result right by count 64-bit elements, and store the low 64 bytes (8 elements) in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ALIGNR_EPI64,
        ///<summary>Concatenate a and b into a 128-byte immediate result, shift the result right by count 64-bit elements, and stores the low 64 bytes (8 elements) in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_ALIGNR_EPI64,
        ///<summary>Concatenate 16-byte blocks in a and b into a 32-byte temporary result, shift the result right by count bytes, and store the low 16 bytes in dst. (SSSE3)</summary>
        _MM_ALIGNR_EPI8,
        ///<summary>Concatenate pairs of 16-byte blocks in a and b into a 32-byte temporary result, shift the result right by count bytes, and store the low 16 bytes in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_ALIGNR_EPI8,
        ///<summary>Concatenate pairs of 16-byte blocks in a and b into a 32-byte temporary result, shift the result right by count bytes, and store the low 16 bytes in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_ALIGNR_EPI8,
        ///<summary>Concatenate pairs of 16-byte blocks in a and b into a 32-byte temporary result, shift the result right by count bytes, and store the low 16 bytes in dst. (AVX2)</summary>
        _MM256_ALIGNR_EPI8,
        ///<summary>Concatenate pairs of 16-byte blocks in a and b into a 32-byte temporary result, shift the result right by count bytes, and store the low 16 bytes in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_ALIGNR_EPI8,
        ///<summary>Concatenate pairs of 16-byte blocks in a and b into a 32-byte temporary result, shift the result right by count bytes, and store the low 16 bytes in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_ALIGNR_EPI8,
        ///<summary>Concatenate pairs of 16-byte blocks in a and b into a 32-byte temporary result, shift the result right by count bytes, and store the low 16 bytes in dst. (AVX512BW)</summary>
        _MM512_ALIGNR_EPI8,
        ///<summary>Concatenate pairs of 16-byte blocks in a and b into a 32-byte temporary result, shift the result right by count bytes, and store the low 16 bytes in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_ALIGNR_EPI8,
        ///<summary>Concatenate pairs of 16-byte blocks in a and b into a 32-byte temporary result, shift the result right by count bytes, and store the low 16 bytes in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_ALIGNR_EPI8,
        ///<summary>Concatenate 8-byte blocks in a and b into a 16-byte temporary result, shift the result right by count bytes, and store the low 16 bytes in dst. (SSSE3)</summary>
        _MM_ALIGNR_PI8,
        ///<summary>Treat the processor-specific feature(s) specified in a as available. Multiple features may be OR'd together. See the valid feature flags below: ()</summary>
        _ALLOW_CPU_FEATURES,
        ///<summary>Compute the bitwise AND of packed 32-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_AND_EPI32,
        ///<summary>Compute the bitwise AND of packed 32-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_AND_EPI32,
        ///<summary>Compute the bitwise AND of packed 32-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_AND_EPI32,
        ///<summary>Compute the bitwise AND of packed 32-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_AND_EPI32,
        ///<summary>Compute the bitwise AND of packed 32-bit integers in a and b, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_AND_EPI32,
        ///<summary>Performs element-by-element bitwise AND between packed 32-bit integer elements of v2 and v3, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_AND_EPI32,
        ///<summary>Compute the bitwise AND of packed 32-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_AND_EPI32,
        ///<summary>Compute the bitwise AND of packed 64-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_AND_EPI64,
        ///<summary>Compute the bitwise AND of packed 64-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_AND_EPI64,
        ///<summary>Compute the bitwise AND of packed 64-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_AND_EPI64,
        ///<summary>Compute the bitwise AND of packed 64-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_AND_EPI64,
        ///<summary>Compute the bitwise AND of 512 bits (composed of packed 64-bit integers) in a and b, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_AND_EPI64,
        ///<summary>Compute the bitwise AND of packed 64-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_AND_EPI64,
        ///<summary>Compute the bitwise AND of packed 64-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_AND_EPI64,
        ///<summary>Compute the bitwise AND of packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst. (SSE2)</summary>
        _MM_AND_PD,
        ///<summary>Compute the bitwise AND of packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_AND_PD,
        ///<summary>Compute the bitwise AND of packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_AND_PD,
        ///<summary>Compute the bitwise AND of packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst. (AVX)</summary>
        _MM256_AND_PD,
        ///<summary>Compute the bitwise AND of packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_AND_PD,
        ///<summary>Compute the bitwise AND of packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_AND_PD,
        ///<summary>Compute the bitwise AND of packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst. (AVX512DQ)</summary>
        _MM512_AND_PD,
        ///<summary>Compute the bitwise AND of packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_AND_PD,
        ///<summary>Compute the bitwise AND of packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_AND_PD,
        ///<summary>Compute the bitwise AND of packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst. (SSE)</summary>
        _MM_AND_PS,
        ///<summary>Compute the bitwise AND of packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_AND_PS,
        ///<summary>Compute the bitwise AND of packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_AND_PS,
        ///<summary>Compute the bitwise AND of packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst. (AVX)</summary>
        _MM256_AND_PS,
        ///<summary>Compute the bitwise AND of packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_AND_PS,
        ///<summary>Compute the bitwise AND of packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_AND_PS,
        ///<summary>Compute the bitwise AND of packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst. (AVX512DQ)</summary>
        _MM512_AND_PS,
        ///<summary>Compute the bitwise AND of packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_AND_PS,
        ///<summary>Compute the bitwise AND of packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_AND_PS,
        ///<summary>Compute the bitwise AND of 128 bits (representing integer data) in a and b, and store the result in dst. (SSE2)</summary>
        _MM_AND_SI128,
        ///<summary>Compute the bitwise AND of 256 bits (representing integer data) in a and b, and store the result in dst. (AVX2)</summary>
        _MM256_AND_SI256,
        ///<summary>Compute the bitwise AND of 512 bits (representing integer data) in a and b, and store the result in dst. (AVX512F, KNCNI)</summary>
        _MM512_AND_SI512,
        ///<summary>Compute the bitwise AND of 64 bits (representing integer data) in a and b, and store the result in dst. (MMX)</summary>
        _MM_AND_SI64,
        ///<summary>Compute the bitwise NOT of packed 32-bit integers in a and then AND with b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_ANDNOT_EPI32,
        ///<summary>Compute the bitwise NOT of packed 32-bit integers in a and then AND with b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_ANDNOT_EPI32,
        ///<summary>Compute the bitwise NOT of packed 32-bit integers in a and then AND with b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_ANDNOT_EPI32,
        ///<summary>Compute the bitwise NOT of packed 32-bit integers in a and then AND with b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_ANDNOT_EPI32,
        ///<summary>Compute the bitwise NOT of packed 32-bit integers in a and then AND with b, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_ANDNOT_EPI32,
        ///<summary>Compute the bitwise NOT of packed 32-bit integers in a and then AND with b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_ANDNOT_EPI32,
        ///<summary>Compute the bitwise NOT of packed 32-bit integers in a and then AND with b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_ANDNOT_EPI32,
        ///<summary>Compute the bitwise NOT of packed 64-bit integers in a and then AND with b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_ANDNOT_EPI64,
        ///<summary>Compute the bitwise NOT of packed 64-bit integers in a and then AND with b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_ANDNOT_EPI64,
        ///<summary>Compute the bitwise NOT of packed 64-bit integers in a and then AND with b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_ANDNOT_EPI64,
        ///<summary>Compute the bitwise NOT of packed 64-bit integers in a and then AND with b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_ANDNOT_EPI64,
        ///<summary>Compute the bitwise NOT of 512 bits (composed of packed 64-bit integers) in a and then AND with b, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_ANDNOT_EPI64,
        ///<summary>Compute the bitwise NOT of packed 64-bit integers in a and then AND with b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_ANDNOT_EPI64,
        ///<summary>Compute the bitwise NOT of packed 64-bit integers in a and then AND with b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_ANDNOT_EPI64,
        ///<summary>Compute the bitwise NOT of packed double-precision (64-bit) floating-point elements in a and then AND with b, and store the results in dst. (SSE2)</summary>
        _MM_ANDNOT_PD,
        ///<summary>Compute the bitwise NOT of packed double-precision (64-bit) floating-point elements in a and then AND with b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_ANDNOT_PD,
        ///<summary>Compute the bitwise NOT of packed double-precision (64-bit) floating-point elements in a and then AND with b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_ANDNOT_PD,
        ///<summary>Compute the bitwise NOT of packed double-precision (64-bit) floating-point elements in a and then AND with b, and store the results in dst. (AVX)</summary>
        _MM256_ANDNOT_PD,
        ///<summary>Compute the bitwise NOT of packed double-precision (64-bit) floating-point elements in a and then AND with b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_ANDNOT_PD,
        ///<summary>Compute the bitwise NOT of packed double-precision (64-bit) floating-point elements in a and then AND with b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_ANDNOT_PD,
        ///<summary>Compute the bitwise NOT of packed double-precision (64-bit) floating-point elements in a and then AND with b, and store the results in dst. (AVX512DQ)</summary>
        _MM512_ANDNOT_PD,
        ///<summary>Compute the bitwise NOT of packed double-precision (64-bit) floating-point elements in a and then AND with b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_ANDNOT_PD,
        ///<summary>Compute the bitwise NOT of packed double-precision (64-bit) floating-point elements in a and then AND with b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_ANDNOT_PD,
        ///<summary>Compute the bitwise NOT of packed single-precision (32-bit) floating-point elements in a and then AND with b, and store the results in dst. (SSE)</summary>
        _MM_ANDNOT_PS,
        ///<summary>Compute the bitwise NOT of packed single-precision (32-bit) floating-point elements in a and then AND with b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_ANDNOT_PS,
        ///<summary>Compute the bitwise NOT of packed single-precision (32-bit) floating-point elements in a and then AND with b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_ANDNOT_PS,
        ///<summary>Compute the bitwise NOT of packed single-precision (32-bit) floating-point elements in a and then AND with b, and store the results in dst. (AVX)</summary>
        _MM256_ANDNOT_PS,
        ///<summary>Compute the bitwise NOT of packed single-precision (32-bit) floating-point elements in a and then AND with b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_ANDNOT_PS,
        ///<summary>Compute the bitwise NOT of packed single-precision (32-bit) floating-point elements in a and then AND with b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_ANDNOT_PS,
        ///<summary>Compute the bitwise NOT of packed single-precision (32-bit) floating-point elements in a and then AND with b, and store the results in dst. (AVX512DQ)</summary>
        _MM512_ANDNOT_PS,
        ///<summary>Compute the bitwise NOT of packed single-precision (32-bit) floating-point elements in a and then AND with b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_ANDNOT_PS,
        ///<summary>Compute the bitwise NOT of packed single-precision (32-bit) floating-point elements in a and then AND with b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_ANDNOT_PS,
        ///<summary>Compute the bitwise NOT of 128 bits (representing integer data) in a and then AND with b, and store the result in dst. (SSE2)</summary>
        _MM_ANDNOT_SI128,
        ///<summary>Compute the bitwise NOT of 256 bits (representing integer data) in a and then AND with b, and store the result in dst. (AVX2)</summary>
        _MM256_ANDNOT_SI256,
        ///<summary>Compute the bitwise NOT of 512 bits (representing integer data) in a and then AND with b, and store the result in dst. (AVX512F, KNCNI)</summary>
        _MM512_ANDNOT_SI512,
        ///<summary>Compute the bitwise NOT of 64 bits (representing integer data) in a and then AND with b, and store the result in dst. (MMX)</summary>
        _MM_ANDNOT_SI64,
        ///<summary>Compute the inverse sine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_ASIN_PD,
        ///<summary>Compute the inverse sine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_ASIN_PD,
        ///<summary>Compute the inverse sine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX512F)</summary>
        _MM512_ASIN_PD,
        ///<summary>Compute the inverse sine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ASIN_PD,
        ///<summary>Compute the inverse sine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_ASIN_PS,
        ///<summary>Compute the inverse sine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_ASIN_PS,
        ///<summary>Compute the inverse sine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX512F)</summary>
        _MM512_ASIN_PS,
        ///<summary>Compute the inverse sine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ASIN_PS,
        ///<summary>Compute the inverse hyperbolic sine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_ASINH_PD,
        ///<summary>Compute the inverse hyperbolic sine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_ASINH_PD,
        ///<summary>Compute the inverse hyperbolic sine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX512F)</summary>
        _MM512_ASINH_PD,
        ///<summary>Compute the inverse hyperbolic sine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ASINH_PD,
        ///<summary>Compute the inverse hyperbolic sine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_ASINH_PS,
        ///<summary>Compute the inverse hyperbolic sine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_ASINH_PS,
        ///<summary>Compute the inverse hyperbolic sine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX512F)</summary>
        _MM512_ASINH_PS,
        ///<summary>Compute the inverse hyperbolic sine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ASINH_PS,
        ///<summary>Compute the inverse tangent of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_ATAN_PD,
        ///<summary>Compute the inverse tangent of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_ATAN_PD,
        ///<summary>Compute the inverse tangent of packed double-precision (64-bit) floating-point elements in a and store the results in dst expressed in radians. (AVX512F)</summary>
        _MM512_ATAN_PD,
        ///<summary>Compute the inverse tangent of packed double-precision (64-bit) floating-point elements in a, and store the results in dst expressed in radians using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ATAN_PD,
        ///<summary>Compute the inverse tangent of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_ATAN_PS,
        ///<summary>Compute the inverse tangent of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_ATAN_PS,
        ///<summary>Compute the inverse tangent of packed single-precision (32-bit) floating-point elements in a, and store the results in dst expressed in radians. (AVX512F)</summary>
        _MM512_ATAN_PS,
        ///<summary>Compute the inverse tangent of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ATAN_PS,
        ///<summary>Compute the inverse tangent of packed double-precision (64-bit) floating-point elements in a divided by packed elements in b, and store the results in dst expressed in radians. (SSE)</summary>
        _MM_ATAN2_PD,
        ///<summary>Compute the inverse tangent of packed double-precision (64-bit) floating-point elements in a divided by packed elements in b, and store the results in dst expressed in radians. (AVX)</summary>
        _MM256_ATAN2_PD,
        ///<summary>Compute the inverse tangent of packed double-precision (64-bit) floating-point elements in a divided by packed elements in b, and store the results in dst expressed in radians. (AVX512F)</summary>
        _MM512_ATAN2_PD,
        ///<summary>Compute the inverse tangent of packed double-precision (64-bit) floating-point elements in a divided by packed elements in b, and store the results in dst expressed in radians using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ATAN2_PD,
        ///<summary>Compute the inverse tangent of packed single-precision (32-bit) floating-point elements in a divided by packed elements in b, and store the results in dst expressed in radians. (SSE)</summary>
        _MM_ATAN2_PS,
        ///<summary>Compute the inverse tangent of packed single-precision (32-bit) floating-point elements in a divided by packed elements in b, and store the results in dst expressed in radians. (AVX)</summary>
        _MM256_ATAN2_PS,
        ///<summary>Compute the inverse tangent of packed single-precision (32-bit) floating-point elements in a divided by packed elements in b, and store the results in dst expressed in radians. (AVX512F)</summary>
        _MM512_ATAN2_PS,
        ///<summary>Compute the inverse tangent of packed single-precision (32-bit) floating-point elements in a divided by packed elements in b, and store the results in dst expressed in radians using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ATAN2_PS,
        ///<summary>Compute the inverse hyperbolic tangent of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_ATANH_PD,
        ///<summary>Compute the inverse hyperbolic tangent of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_ATANH_PD,
        ///<summary>Compute the inverse hyperbolic tangent of packed double-precision (64-bit) floating-point elements in a and store the results in dst expressed in radians. (AVX512F)</summary>
        _MM512_ATANH_PD,
        ///<summary>Compute the inverse hyperbolic tangent of packed double-precision (64-bit) floating-point elements in a, and store the results in dst expressed in radians using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ATANH_PD,
        ///<summary>Compute the inverse hyperbolic tangent of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_ATANH_PS,
        ///<summary>Compute the inverse hyperbolic tangent of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_ATANH_PS,
        ///<summary>Compute the inverse hyperblic tangent of packed single-precision (32-bit) floating-point elements in a, and store the results in dst expressed in radians. (AVX512F)</summary>
        _MM512_ATANH_PS,
        ///<summary>Compute the inverse hyperbolic tangent of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ATANH_PS,
        ///<summary>Average packed unsigned 16-bit integers in a and b, and store the results in dst. (SSE2)</summary>
        _MM_AVG_EPU16,
        ///<summary>Average packed unsigned 16-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_AVG_EPU16,
        ///<summary>Average packed unsigned 16-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_AVG_EPU16,
        ///<summary>Average packed unsigned 16-bit integers in a and b, and store the results in dst. (AVX2)</summary>
        _MM256_AVG_EPU16,
        ///<summary>Average packed unsigned 16-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_AVG_EPU16,
        ///<summary>Average packed unsigned 16-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_AVG_EPU16,
        ///<summary>Average packed unsigned 16-bit integers in a and b, and store the results in dst. (AVX512BW)</summary>
        _MM512_AVG_EPU16,
        ///<summary>Average packed unsigned 16-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_AVG_EPU16,
        ///<summary>Average packed unsigned 16-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_AVG_EPU16,
        ///<summary>Average packed unsigned 8-bit integers in a and b, and store the results in dst. (SSE2)</summary>
        _MM_AVG_EPU8,
        ///<summary>Average packed unsigned 8-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_AVG_EPU8,
        ///<summary>Average packed unsigned 8-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_AVG_EPU8,
        ///<summary>Average packed unsigned 8-bit integers in a and b, and store the results in dst. (AVX2)</summary>
        _MM256_AVG_EPU8,
        ///<summary>Average packed unsigned 8-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_AVG_EPU8,
        ///<summary>Average packed unsigned 8-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_AVG_EPU8,
        ///<summary>Average packed unsigned 8-bit integers in a and b, and store the results in dst. (AVX512BW)</summary>
        _MM512_AVG_EPU8,
        ///<summary>Average packed unsigned 8-bit integers in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_AVG_EPU8,
        ///<summary>Average packed unsigned 8-bit integers in a and b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_AVG_EPU8,
        ///<summary>Average packed unsigned 16-bit integers in a and b, and store the results in dst. (SSE)</summary>
        _MM_AVG_PU16,
        ///<summary>Average packed unsigned 8-bit integers in a and b, and store the results in dst. (SSE)</summary>
        _MM_AVG_PU8,
        ///<summary>Extract contiguous bits from unsigned 32-bit integer a, and store the result in dst. Extract the number of bits specified by len, starting at the bit specified by start. (BMI1)</summary>
        _BEXTR_U32,
        ///<summary>Extract contiguous bits from unsigned 64-bit integer a, and store the result in dst. Extract the number of bits specified by len, starting at the bit specified by start. (BMI1)</summary>
        _BEXTR_U64,
        ///<summary>Set dst to the index of the lowest set bit in 32-bit integer a. If no bits are set in a then dst is undefined. ()</summary>
        _BIT_SCAN_FORWARD,
        ///<summary>Set dst to the index of the highest set bit in 32-bit integer a. If no bits are set in a then dst is undefined. ()</summary>
        _BIT_SCAN_REVERSE,
        ///<summary>Set index to the index of the lowest set bit in 32-bit integer mask. If no bits are set in mask, then set dst to 0, otherwise set dst to 1. ()</summary>
        _BITSCANFORWARD,
        ///<summary>Set index to the index of the lowest set bit in 64-bit integer mask. If no bits are set in mask, then set dst to 0, otherwise set dst to 1. ()</summary>
        _BITSCANFORWARD64,
        ///<summary>Set index to the index of the highest set bit in 32-bit integer mask. If no bits are set in mask, then set dst to 0, otherwise set dst to 1. ()</summary>
        _BITSCANREVERSE,
        ///<summary>Set index to the index of the highest set bit in 64-bit integer mask. If no bits are set in mask, then set dst to 0, otherwise set dst to 1. ()</summary>
        _BITSCANREVERSE64,
        ///<summary>Return the bit at index b of 32-bit integer a. ()</summary>
        _BITTEST,
        ///<summary>Return the bit at index b of 64-bit integer a. ()</summary>
        _BITTEST64,
        ///<summary>Return the bit at index b of 32-bit integer a, and set that bit to its complement. ()</summary>
        _BITTESTANDCOMPLEMENT,
        ///<summary>Return the bit at index b of 64-bit integer a, and set that bit to its complement. ()</summary>
        _BITTESTANDCOMPLEMENT64,
        ///<summary>Return the bit at index b of 32-bit integer a, and set that bit to zero. ()</summary>
        _BITTESTANDRESET,
        ///<summary>Return the bit at index b of 64-bit integer a, and set that bit to zero. ()</summary>
        _BITTESTANDRESET64,
        ///<summary>Return the bit at index b of 32-bit integer a, and set that bit to one. ()</summary>
        _BITTESTANDSET,
        ///<summary>Return the bit at index b of 64-bit integer a, and set that bit to one. ()</summary>
        _BITTESTANDSET64,
        ///<summary>Blend packed 16-bit integers from a and b using control mask imm8, and store the results in dst. (SSE4.1)</summary>
        _MM_BLEND_EPI16,
        ///<summary>Blend packed 16-bit integers from a and b using control mask k, and store the results in dst. (AVX512VL, AVX512BW)</summary>
        _MM_MASK_BLEND_EPI16,
        ///<summary>Blend packed 16-bit integers from a and b using control mask imm8, and store the results in dst. (AVX2)</summary>
        _MM256_BLEND_EPI16,
        ///<summary>Blend packed 16-bit integers from a and b using control mask k, and store the results in dst. (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_BLEND_EPI16,
        ///<summary>Blend packed 16-bit integers from a and b using control mask k, and store the results in dst. (AVX512BW)</summary>
        _MM512_MASK_BLEND_EPI16,
        ///<summary>Blend packed 32-bit integers from a and b using control mask imm8, and store the results in dst. (AVX2)</summary>
        _MM_BLEND_EPI32,
        ///<summary>Blend packed 32-bit integers from a and b using control mask k, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_MASK_BLEND_EPI32,
        ///<summary>Blend packed 32-bit integers from a and b using control mask imm8, and store the results in dst. (AVX2)</summary>
        _MM256_BLEND_EPI32,
        ///<summary>Blend packed 32-bit integers from a and b using control mask k, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_BLEND_EPI32,
        ///<summary>Blend packed 32-bit integers from a and b using control mask k, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_MASK_BLEND_EPI32,
        ///<summary>Blend packed 64-bit integers from a and b using control mask k, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_MASK_BLEND_EPI64,
        ///<summary>Blend packed 64-bit integers from a and b using control mask k, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_BLEND_EPI64,
        ///<summary>Blend packed 64-bit integers from a and b using control mask k, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_MASK_BLEND_EPI64,
        ///<summary>Blend packed 8-bit integers from a and b using control mask k, and store the results in dst. (AVX512VL, AVX512BW)</summary>
        _MM_MASK_BLEND_EPI8,
        ///<summary>Blend packed 8-bit integers from a and b using control mask k, and store the results in dst. (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_BLEND_EPI8,
        ///<summary>Blend packed 8-bit integers from a and b using control mask k, and store the results in dst. (AVX512BW)</summary>
        _MM512_MASK_BLEND_EPI8,
        ///<summary>Blend packed double-precision (64-bit) floating-point elements from a and b using control mask imm8, and store the results in dst. (SSE4.1)</summary>
        _MM_BLEND_PD,
        ///<summary>Blend packed double-precision (64-bit) floating-point elements from a and b using control mask k, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_MASK_BLEND_PD,
        ///<summary>Blend packed double-precision (64-bit) floating-point elements from a and b using control mask imm8, and store the results in dst. (AVX)</summary>
        _MM256_BLEND_PD,
        ///<summary>Blend packed double-precision (64-bit) floating-point elements from a and b using control mask k, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_BLEND_PD,
        ///<summary>Blend packed double-precision (64-bit) floating-point elements from a and b using control mask k, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_MASK_BLEND_PD,
        ///<summary>Blend packed single-precision (32-bit) floating-point elements from a and b using control mask imm8, and store the results in dst. (SSE4.1)</summary>
        _MM_BLEND_PS,
        ///<summary>Blend packed single-precision (32-bit) floating-point elements from a and b using control mask k, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_MASK_BLEND_PS,
        ///<summary>Blend packed single-precision (32-bit) floating-point elements from a and b using control mask imm8, and store the results in dst. (AVX)</summary>
        _MM256_BLEND_PS,
        ///<summary>Blend packed single-precision (32-bit) floating-point elements from a and b using control mask k, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_BLEND_PS,
        ///<summary>Blend packed single-precision (32-bit) floating-point elements from a and b using control mask k, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_MASK_BLEND_PS,
        ///<summary>Blend packed 8-bit integers from a and b using mask, and store the results in dst. (SSE4.1)</summary>
        _MM_BLENDV_EPI8,
        ///<summary>Blend packed 8-bit integers from a and b using mask, and store the results in dst. (AVX2)</summary>
        _MM256_BLENDV_EPI8,
        ///<summary>Blend packed double-precision (64-bit) floating-point elements from a and b using mask, and store the results in dst. (SSE4.1)</summary>
        _MM_BLENDV_PD,
        ///<summary>Blend packed double-precision (64-bit) floating-point elements from a and b using mask, and store the results in dst. (AVX)</summary>
        _MM256_BLENDV_PD,
        ///<summary>Blend packed single-precision (32-bit) floating-point elements from a and b using mask, and store the results in dst. (SSE4.1)</summary>
        _MM_BLENDV_PS,
        ///<summary>Blend packed single-precision (32-bit) floating-point elements from a and b using mask, and store the results in dst. (AVX)</summary>
        _MM256_BLENDV_PS,
        ///<summary>Extract the lowest set bit from unsigned 32-bit integer a and set the corresponding bit in dst. All other bits in dst are zeroed, and all bits are zeroed if no bits are set in a. (BMI1)</summary>
        _BLSI_U32,
        ///<summary>Extract the lowest set bit from unsigned 64-bit integer a and set the corresponding bit in dst. All other bits in dst are zeroed, and all bits are zeroed if no bits are set in a. (BMI1)</summary>
        _BLSI_U64,
        ///<summary>Set all the lower bits of dst up to and including the lowest set bit in unsigned 32-bit integer a. (BMI1)</summary>
        _BLSMSK_U32,
        ///<summary>Set all the lower bits of dst up to and including the lowest set bit in unsigned 64-bit integer a. (BMI1)</summary>
        _BLSMSK_U64,
        ///<summary>Copy all bits from unsigned 32-bit integer a to dst, and reset (set to 0) the bit in dst that corresponds to the lowest set bit in a. (BMI1)</summary>
        _BLSR_U32,
        ///<summary>Copy all bits from unsigned 64-bit integer a to dst, and reset (set to 0) the bit in dst that corresponds to the lowest set bit in a. (BMI1)</summary>
        _BLSR_U64,
        ///<summary>Checks if [q, q + size - 1] is within the lower and upper bounds of q and throws a #BR if not. (MPX)</summary>
        _BND_CHK_PTR_BOUNDS,
        ///<summary>Checks if q is within its lower bound, and throws a #BR if not. (MPX)</summary>
        _BND_CHK_PTR_LBOUNDS,
        ///<summary>Checks if q is within its upper bound, and throws a #BR if not. (MPX)</summary>
        _BND_CHK_PTR_UBOUNDS,
        ///<summary>Make a pointer with the value of q and bounds set to the bounds of r (e.g. copy the bounds of r to pointer q), and store the result in dst. (MPX)</summary>
        _BND_COPY_PTR_BOUNDS,
        ///<summary>Return the lower bound of q. (MPX)</summary>
        _BND_GET_PTR_LBOUND,
        ///<summary>Return the upper bound of q. (MPX)</summary>
        _BND_GET_PTR_UBOUND,
        ///<summary>Make a pointer with the value of q and open bounds, which allow the pointer to access the entire virtual address space, and store the result in dst. (MPX)</summary>
        _BND_INIT_PTR_BOUNDS,
        ///<summary>Narrow the bounds for pointer q to the intersection of the bounds of r and the bounds [q, q + size - 1], and store the result in dst. (MPX)</summary>
        _BND_NARROW_PTR_BOUNDS,
        ///<summary>Make a pointer with the value of srcmem and bounds set to [srcmem, srcmem + size - 1], and store the result in dst. (MPX)</summary>
        _BND_SET_PTR_BOUNDS,
        ///<summary>Stores the bounds of ptr_val pointer in memory at address ptr_addr. (MPX)</summary>
        _BND_STORE_PTR_BOUNDS,
        ///<summary>Broadcast the lower 2 packed single-precision (32-bit) floating-point elements from a to all elements of dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_BROADCAST_F32X2,
        ///<summary>Broadcast the lower 2 packed single-precision (32-bit) floating-point elements from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_BROADCAST_F32X2,
        ///<summary>Broadcast the lower 2 packed single-precision (32-bit) floating-point elements from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_BROADCAST_F32X2,
        ///<summary>Broadcast the lower 2 packed single-precision (32-bit) floating-point elements from a to all elements of dst. (AVX512DQ)</summary>
        _MM512_BROADCAST_F32X2,
        ///<summary>Broadcast the lower 2 packed single-precision (32-bit) floating-point elements from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_BROADCAST_F32X2,
        ///<summary>Broadcast the lower 2 packed single-precision (32-bit) floating-point elements from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_BROADCAST_F32X2,
        ///<summary>Broadcast the 4 packed single-precision (32-bit) floating-point elements from a to all elements of dst. (AVX512VL, AVX512F)</summary>
        _MM256_BROADCAST_F32X4,
        ///<summary>Broadcast the 4 packed single-precision (32-bit) floating-point elements from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_BROADCAST_F32X4,
        ///<summary>Broadcast the 4 packed single-precision (32-bit) floating-point elements from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_BROADCAST_F32X4,
        ///<summary>Broadcast the 4 packed single-precision (32-bit) floating-point elements from a to all elements of dst. (AVX512F)</summary>
        _MM512_BROADCAST_F32X4,
        ///<summary>Broadcast the 4 packed single-precision (32-bit) floating-point elements from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_BROADCAST_F32X4,
        ///<summary>Broadcast the 4 packed single-precision (32-bit) floating-point elements from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_BROADCAST_F32X4,
        ///<summary>Broadcast the 8 packed single-precision (32-bit) floating-point elements from a to all elements of dst. (AVX512DQ)</summary>
        _MM512_BROADCAST_F32X8,
        ///<summary>Broadcast the 8 packed single-precision (32-bit) floating-point elements from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_BROADCAST_F32X8,
        ///<summary>Broadcast the 8 packed single-precision (32-bit) floating-point elements from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_BROADCAST_F32X8,
        ///<summary>Broadcast the 2 packed double-precision (64-bit) floating-point elements from a to all elements of dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_BROADCAST_F64X2,
        ///<summary>Broadcast the 2 packed double-precision (64-bit) floating-point elements from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_BROADCAST_F64X2,
        ///<summary>Broadcast the 2 packed double-precision (64-bit) floating-point elements from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_BROADCAST_F64X2,
        ///<summary>Broadcast the 2 packed double-precision (64-bit) floating-point elements from a to all elements of dst. (AVX512DQ)</summary>
        _MM512_BROADCAST_F64X2,
        ///<summary>Broadcast the 2 packed double-precision (64-bit) floating-point elements from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_BROADCAST_F64X2,
        ///<summary>Broadcast the 2 packed double-precision (64-bit) floating-point elements from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_BROADCAST_F64X2,
        ///<summary>Broadcast the 4 packed double-precision (64-bit) floating-point elements from a to all elements of dst. (AVX512F)</summary>
        _MM512_BROADCAST_F64X4,
        ///<summary>Broadcast the 4 packed double-precision (64-bit) floating-point elements from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_BROADCAST_F64X4,
        ///<summary>Broadcast the 4 packed double-precision (64-bit) floating-point elements from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_BROADCAST_F64X4,
        ///<summary>Broadcast the lower 2 packed 32-bit integers from a to all elements of "dst. (AVX512VL, AVX512DQ)</summary>
        _MM_BROADCAST_I32X2,
        ///<summary>Broadcast the lower 2 packed 32-bit integers from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_BROADCAST_I32X2,
        ///<summary>Broadcast the lower 2 packed 32-bit integers from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_BROADCAST_I32X2,
        ///<summary>Broadcast the lower 2 packed 32-bit integers from a to all elements of "dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_BROADCAST_I32X2,
        ///<summary>Broadcast the lower 2 packed 32-bit integers from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_BROADCAST_I32X2,
        ///<summary>Broadcast the lower 2 packed 32-bit integers from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_BROADCAST_I32X2,
        ///<summary>Broadcast the lower 2 packed 32-bit integers from a to all elements of "dst. (AVX512DQ)</summary>
        _MM512_BROADCAST_I32X2,
        ///<summary>Broadcast the lower 2 packed 32-bit integers from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_BROADCAST_I32X2,
        ///<summary>Broadcast the lower 2 packed 32-bit integers from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_BROADCAST_I32X2,
        ///<summary>Broadcast the 4 packed 32-bit integers from a to all elements of dst. (AVX512VL, AVX512F)</summary>
        _MM256_BROADCAST_I32X4,
        ///<summary>Broadcast the 4 packed 32-bit integers from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_BROADCAST_I32X4,
        ///<summary>Broadcast the 4 packed 32-bit integers from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_BROADCAST_I32X4,
        ///<summary>Broadcast the 4 packed 32-bit integers from a to all elements of dst. (AVX512F)</summary>
        _MM512_BROADCAST_I32X4,
        ///<summary>Broadcast the 4 packed 32-bit integers from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_BROADCAST_I32X4,
        ///<summary>Broadcast the 4 packed 32-bit integers from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_BROADCAST_I32X4,
        ///<summary>Broadcast the 8 packed 32-bit integers from a to all elements of dst. (AVX512DQ)</summary>
        _MM512_BROADCAST_I32X8,
        ///<summary>Broadcast the 8 packed 32-bit integers from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_BROADCAST_I32X8,
        ///<summary>Broadcast the 8 packed 32-bit integers from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_BROADCAST_I32X8,
        ///<summary>Broadcast the 2 packed 64-bit integers from a to all elements of dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_BROADCAST_I64X2,
        ///<summary>Broadcast the 2 packed 64-bit integers from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_BROADCAST_I64X2,
        ///<summary>Broadcast the 2 packed 64-bit integers from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_BROADCAST_I64X2,
        ///<summary>Broadcast the 2 packed 64-bit integers from a to all elements of dst. (AVX512DQ)</summary>
        _MM512_BROADCAST_I64X2,
        ///<summary>Broadcast the 2 packed 64-bit integers from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_BROADCAST_I64X2,
        ///<summary>Broadcast the 2 packed 64-bit integers from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_BROADCAST_I64X2,
        ///<summary>Broadcast the 4 packed 64-bit integers from a to all elements of dst. (AVX512F)</summary>
        _MM512_BROADCAST_I64X4,
        ///<summary>Broadcast the 4 packed 64-bit integers from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_BROADCAST_I64X4,
        ///<summary>Broadcast the 4 packed 64-bit integers from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_BROADCAST_I64X4,
        ///<summary>Broadcast 128 bits from memory (composed of 2 packed double-precision (64-bit) floating-point elements) to all elements of dst. (AVX)</summary>
        _MM256_BROADCAST_PD,
        ///<summary>Broadcast 128 bits from memory (composed of 4 packed single-precision (32-bit) floating-point elements) to all elements of dst. (AVX)</summary>
        _MM256_BROADCAST_PS,
        ///<summary>Broadcast a double-precision (64-bit) floating-point element from memory to all elements of dst. (AVX)</summary>
        _MM256_BROADCAST_SD,
        ///<summary>Broadcast a single-precision (32-bit) floating-point element from memory to all elements of dst. (AVX)</summary>
        _MM_BROADCAST_SS,
        ///<summary>Broadcast a single-precision (32-bit) floating-point element from memory to all elements of dst. (AVX)</summary>
        _MM256_BROADCAST_SS,
        ///<summary>Broadcast the low packed 8-bit integer from a to all elements of dst. (AVX2)</summary>
        _MM_BROADCASTB_EPI8,
        ///<summary>Broadcast the low packed 8-bit integer from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_BROADCASTB_EPI8,
        ///<summary>Broadcast the low packed 8-bit integer from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_BROADCASTB_EPI8,
        ///<summary>Broadcast the low packed 8-bit integer from a to all elements of dst. (AVX2)</summary>
        _MM256_BROADCASTB_EPI8,
        ///<summary>Broadcast the low packed 8-bit integer from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_BROADCASTB_EPI8,
        ///<summary>Broadcast the low packed 8-bit integer from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_BROADCASTB_EPI8,
        ///<summary>Broadcast the low packed 8-bit integer from a to all elements of dst. (AVX512BW)</summary>
        _MM512_BROADCASTB_EPI8,
        ///<summary>Broadcast the low packed 8-bit integer from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_BROADCASTB_EPI8,
        ///<summary>Broadcast the low packed 8-bit integer from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_BROADCASTB_EPI8,
        ///<summary>Broadcast the low packed 32-bit integer from a to all elements of dst. (AVX2)</summary>
        _MM_BROADCASTD_EPI32,
        ///<summary>Broadcast the low packed 32-bit integer from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_BROADCASTD_EPI32,
        ///<summary>Broadcast the low packed 32-bit integer from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_BROADCASTD_EPI32,
        ///<summary>Broadcast the low packed 32-bit integer from a to all elements of dst. (AVX2)</summary>
        _MM256_BROADCASTD_EPI32,
        ///<summary>Broadcast the low packed 32-bit integer from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_BROADCASTD_EPI32,
        ///<summary>Broadcast the low packed 32-bit integer from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_BROADCASTD_EPI32,
        ///<summary>Broadcast the low packed 32-bit integer from a to all elements of dst. (AVX512F)</summary>
        _MM512_BROADCASTD_EPI32,
        ///<summary>Broadcast the low packed 32-bit integer from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_BROADCASTD_EPI32,
        ///<summary>Broadcast the low packed 32-bit integer from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_BROADCASTD_EPI32,
        ///<summary>Broadcast the low 8-bits from input mask k to all 64-bit elements of dst. (AVX512VL, AVX512CD)</summary>
        _MM_BROADCASTMB_EPI64,
        ///<summary>Broadcast the low 8-bits from input mask k to all 64-bit elements of dst. (AVX512VL, AVX512CD)</summary>
        _MM256_BROADCASTMB_EPI64,
        ///<summary>Broadcast the low 8-bits from input mask k to all 64-bit elements of dst. (AVX512CD)</summary>
        _MM512_BROADCASTMB_EPI64,
        ///<summary>Broadcast the low 16-bits from input mask k to all 32-bit elements of dst. (AVX512VL, AVX512CD)</summary>
        _MM_BROADCASTMW_EPI32,
        ///<summary>Broadcast the low 16-bits from input mask k to all 32-bit elements of dst. (AVX512VL, AVX512CD)</summary>
        _MM256_BROADCASTMW_EPI32,
        ///<summary>Broadcast the low 16-bits from input mask k to all 32-bit elements of dst. (AVX512CD)</summary>
        _MM512_BROADCASTMW_EPI32,
        ///<summary>Broadcast the low packed 64-bit integer from a to all elements of dst. (AVX2)</summary>
        _MM_BROADCASTQ_EPI64,
        ///<summary>Broadcast the low packed 64-bit integer from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_BROADCASTQ_EPI64,
        ///<summary>Broadcast the low packed 64-bit integer from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_BROADCASTQ_EPI64,
        ///<summary>Broadcast the low packed 64-bit integer from a to all elements of dst. (AVX2)</summary>
        _MM256_BROADCASTQ_EPI64,
        ///<summary>Broadcast the low packed 64-bit integer from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_BROADCASTQ_EPI64,
        ///<summary>Broadcast the low packed 64-bit integer from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_BROADCASTQ_EPI64,
        ///<summary>Broadcast the low packed 64-bit integer from a to all elements of dst. (AVX512F)</summary>
        _MM512_BROADCASTQ_EPI64,
        ///<summary>Broadcast the low packed 64-bit integer from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_BROADCASTQ_EPI64,
        ///<summary>Broadcast the low packed 64-bit integer from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_BROADCASTQ_EPI64,
        ///<summary>Broadcast the low double-precision (64-bit) floating-point element from a to all elements of dst. (AVX2)</summary>
        _MM_BROADCASTSD_PD,
        ///<summary>Broadcast the low double-precision (64-bit) floating-point element from a to all elements of dst. (AVX2)</summary>
        _MM256_BROADCASTSD_PD,
        ///<summary>Broadcast the low double-precision (64-bit) floating-point element from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_BROADCASTSD_PD,
        ///<summary>Broadcast the low double-precision (64-bit) floating-point element from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_BROADCASTSD_PD,
        ///<summary>Broadcast the low double-precision (64-bit) floating-point element from a to all elements of dst. (AVX512F)</summary>
        _MM512_BROADCASTSD_PD,
        ///<summary>Broadcast the low double-precision (64-bit) floating-point element from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_BROADCASTSD_PD,
        ///<summary>Broadcast the low double-precision (64-bit) floating-point element from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_BROADCASTSD_PD,
        ///<summary>Broadcast 128 bits of integer data from a to all 128-bit lanes in dst. (AVX2)</summary>
        _MM256_BROADCASTSI128_SI256,
        ///<summary>Broadcast the low single-precision (32-bit) floating-point element from a to all elements of dst. (AVX2)</summary>
        _MM_BROADCASTSS_PS,
        ///<summary>Broadcast the low single-precision (32-bit) floating-point element from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_BROADCASTSS_PS,
        ///<summary>Broadcast the low single-precision (32-bit) floating-point element from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_BROADCASTSS_PS,
        ///<summary>Broadcast the low single-precision (32-bit) floating-point element from a to all elements of dst. (AVX2)</summary>
        _MM256_BROADCASTSS_PS,
        ///<summary>Broadcast the low single-precision (32-bit) floating-point element from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_BROADCASTSS_PS,
        ///<summary>Broadcast the low single-precision (32-bit) floating-point element from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_BROADCASTSS_PS,
        ///<summary>Broadcast the low single-precision (32-bit) floating-point element from a to all elements of dst. (AVX512F)</summary>
        _MM512_BROADCASTSS_PS,
        ///<summary>Broadcast the low single-precision (32-bit) floating-point element from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_BROADCASTSS_PS,
        ///<summary>Broadcast the low single-precision (32-bit) floating-point element from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_BROADCASTSS_PS,
        ///<summary>Broadcast the low packed 16-bit integer from a to all elements of dst. (AVX2)</summary>
        _MM_BROADCASTW_EPI16,
        ///<summary>Broadcast the low packed 16-bit integer from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_BROADCASTW_EPI16,
        ///<summary>Broadcast the low packed 16-bit integer from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_BROADCASTW_EPI16,
        ///<summary>Broadcast the low packed 16-bit integer from a to all elements of dst. (AVX2)</summary>
        _MM256_BROADCASTW_EPI16,
        ///<summary>Broadcast the low packed 16-bit integer from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_BROADCASTW_EPI16,
        ///<summary>Broadcast the low packed 16-bit integer from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_BROADCASTW_EPI16,
        ///<summary>Broadcast the low packed 16-bit integer from a to all elements of dst. (AVX512BW)</summary>
        _MM512_BROADCASTW_EPI16,
        ///<summary>Broadcast the low packed 16-bit integer from a to all elements of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_BROADCASTW_EPI16,
        ///<summary>Broadcast the low packed 16-bit integer from a to all elements of dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_BROADCASTW_EPI16,
        ///<summary>Shift 128-bit lanes in a left by imm8 bytes while shifting in zeros, and store the results in dst. (AVX2)</summary>
        _MM256_BSLLI_EPI128,
        ///<summary>Shift 128-bit lanes in a left by imm8 bytes while shifting in zeros, and store the results in dst. (AVX512BW)</summary>
        _MM512_BSLLI_EPI128,
        ///<summary>Shift a left by imm8 bytes while shifting in zeros, and store the results in dst. (SSE2)</summary>
        _MM_BSLLI_SI128,
        ///<summary>Shift 128-bit lanes in a right by imm8 bytes while shifting in zeros, and store the results in dst. (AVX2)</summary>
        _MM256_BSRLI_EPI128,
        ///<summary>Shift 128-bit lanes in a right by imm8 bytes while shifting in zeros, and store the results in dst. (AVX512BW)</summary>
        _MM512_BSRLI_EPI128,
        ///<summary>Shift a right by imm8 bytes while shifting in zeros, and store the results in dst. (SSE2)</summary>
        _MM_BSRLI_SI128,
        ///<summary>Reverse the byte order of 32-bit integer a, and store the result in dst. This intrinsic is provided for conversion between little and big endian values. ()</summary>
        _BSWAP,
        ///<summary>Reverse the byte order of 64-bit integer a, and store the result in dst. This intrinsic is provided for conversion between little and big endian values. ()</summary>
        _BSWAP64,
        ///<summary>Copy all bits from unsigned 32-bit integer a to dst, and reset (set to 0) the high bits in dst starting at index. (BMI2)</summary>
        _BZHI_U32,
        ///<summary>Copy all bits from unsigned 64-bit integer a to dst, and reset (set to 0) the high bits in dst starting at index. (BMI2)</summary>
        _BZHI_U64,
        ///<summary>Cast from type float to type unsigned __int32 without conversion. 	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. ()</summary>
        _CASTF32_U32,
        ///<summary>Cast from type double to type unsigned __int64 without conversion. 	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. ()</summary>
        _CASTF64_U64,
        ///<summary>Cast vector of type __m128d to type __m128. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (SSE2)</summary>
        _MM_CASTPD_PS,
        ///<summary>Cast vector of type __m256d to type __m256. 	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX)</summary>
        _MM256_CASTPD_PS,
        ///<summary>Cast vector of type __m512d to type __m512. 	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F, KNCNI)</summary>
        _MM512_CASTPD_PS,
        ///<summary>Cast vector of type __m128d to type __m128i. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (SSE2)</summary>
        _MM_CASTPD_SI128,
        ///<summary>Casts vector of type __m256d to type __m256i. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX)</summary>
        _MM256_CASTPD_SI256,
        ///<summary>Cast vector of type __m512d to type __m512i. 	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F, KNCNI)</summary>
        _MM512_CASTPD_SI512,
        ///<summary>Casts vector of type __m128d to type __m256d; the upper 128 bits of the result are undefined. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX)</summary>
        _MM256_CASTPD128_PD256,
        ///<summary>Cast vector of type __m128d to type __m512d; the upper 384 bits of the result are undefined.  	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F)</summary>
        _MM512_CASTPD128_PD512,
        ///<summary>Casts vector of type __m256d to type __m128d. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX)</summary>
        _MM256_CASTPD256_PD128,
        ///<summary>Cast vector of type __m256d to type __m512d; the upper 256 bits of the result are undefined.  	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F)</summary>
        _MM512_CASTPD256_PD512,
        ///<summary>Cast vector of type __m512d to type __m128d.  	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F)</summary>
        _MM512_CASTPD512_PD128,
        ///<summary>Cast vector of type __m512d to type __m256d.  	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F)</summary>
        _MM512_CASTPD512_PD256,
        ///<summary>Cast vector of type __m128 to type __m128d. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (SSE2)</summary>
        _MM_CASTPS_PD,
        ///<summary>Cast vector of type __m256 to type __m256d. 	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX)</summary>
        _MM256_CASTPS_PD,
        ///<summary>Cast vector of type __m512 to type __m512d. 	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F, KNCNI)</summary>
        _MM512_CASTPS_PD,
        ///<summary>Cast vector of type __m128 to type __m128i. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (SSE2)</summary>
        _MM_CASTPS_SI128,
        ///<summary>Casts vector of type __m256 to type __m256i. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX)</summary>
        _MM256_CASTPS_SI256,
        ///<summary>Cast vector of type __m512 to type __m512i. 	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F, KNCNI)</summary>
        _MM512_CASTPS_SI512,
        ///<summary>Casts vector of type __m128 to type __m256; the upper 128 bits of the result are undefined. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX)</summary>
        _MM256_CASTPS128_PS256,
        ///<summary>Cast vector of type __m128 to type __m512; the upper 384 bits of the result are undefined.  	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F)</summary>
        _MM512_CASTPS128_PS512,
        ///<summary>Casts vector of type __m256 to type __m128. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX)</summary>
        _MM256_CASTPS256_PS128,
        ///<summary>Cast vector of type __m256 to type __m512; the upper 256 bits of the result are undefined.  	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F)</summary>
        _MM512_CASTPS256_PS512,
        ///<summary>Cast vector of type __m512 to type __m128.  	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F)</summary>
        _MM512_CASTPS512_PS128,
        ///<summary>Cast vector of type __m512 to type __m256.  	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F)</summary>
        _MM512_CASTPS512_PS256,
        ///<summary>Cast vector of type __m128i to type __m128d. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (SSE2)</summary>
        _MM_CASTSI128_PD,
        ///<summary>Cast vector of type __m128i to type __m128. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (SSE2)</summary>
        _MM_CASTSI128_PS,
        ///<summary>Casts vector of type __m128i to type __m256i; the upper 128 bits of the result are undefined. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX)</summary>
        _MM256_CASTSI128_SI256,
        ///<summary>Cast vector of type __m128i to type __m512i; the upper 384 bits of the result are undefined.  	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F)</summary>
        _MM512_CASTSI128_SI512,
        ///<summary>Casts vector of type __m256i to type __m256d. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX)</summary>
        _MM256_CASTSI256_PD,
        ///<summary>Casts vector of type __m256i to type __m256. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX)</summary>
        _MM256_CASTSI256_PS,
        ///<summary>Casts vector of type __m256i to type __m128i. This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX)</summary>
        _MM256_CASTSI256_SI128,
        ///<summary>Cast vector of type __m256i to type __m512i; the upper 256 bits of the result are undefined. 	 This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F)</summary>
        _MM512_CASTSI256_SI512,
        ///<summary>Cast vector of type __m512i to type __m512d. 	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F, KNCNI)</summary>
        _MM512_CASTSI512_PD,
        ///<summary>Cast vector of type __m512i to type __m512. 	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F, KNCNI)</summary>
        _MM512_CASTSI512_PS,
        ///<summary>Cast vector of type __m512i to type __m128i. 	 This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F)</summary>
        _MM512_CASTSI512_SI128,
        ///<summary>Cast vector of type __m512i to type __m256i. 	 This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. (AVX512F)</summary>
        _MM512_CASTSI512_SI256,
        ///<summary>Cast from type unsigned __int32 to type float without conversion. 	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. ()</summary>
        _CASTU32_F32,
        ///<summary>Cast from type unsigned __int64 to type double without conversion. 	This intrinsic is only used for compilation and does not generate any instructions, thus it has zero latency. ()</summary>
        _CASTU64_F64,
        ///<summary>Compute the cube root of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_CBRT_PD,
        ///<summary>Compute the cube root of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_CBRT_PD,
        ///<summary>Compute the cube root of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_CBRT_PD,
        ///<summary>Compute the cube root of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CBRT_PD,
        ///<summary>Compute the cube root of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_CBRT_PS,
        ///<summary>Compute the cube root of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_CBRT_PS,
        ///<summary>Compute the cube root of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_CBRT_PS,
        ///<summary>Compute the cube root of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CBRT_PS,
        ///<summary>Compute the cumulative distribution function of packed double-precision (64-bit) floating-point elements in a using the normal distribution, and store the results in dst. (SSE)</summary>
        _MM_CDFNORM_PD,
        ///<summary>Compute the cumulative distribution function of packed double-precision (64-bit) floating-point elements in a using the normal distribution, and store the results in dst. (AVX)</summary>
        _MM256_CDFNORM_PD,
        ///<summary>Compute the cumulative distribution function of packed double-precision (64-bit) floating-point elements in a using the normal distribution, and store the results in dst. (AVX512F)</summary>
        _MM512_CDFNORM_PD,
        ///<summary>Compute the cumulative distribution function of packed double-precision (64-bit) floating-point elements in a using the normal distribution, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CDFNORM_PD,
        ///<summary>Compute the cumulative distribution function of packed single-precision (32-bit) floating-point elements in a using the normal distribution, and store the results in dst. (SSE)</summary>
        _MM_CDFNORM_PS,
        ///<summary>Compute the cumulative distribution function of packed single-precision (32-bit) floating-point elements in a using the normal distribution, and store the results in dst. (AVX)</summary>
        _MM256_CDFNORM_PS,
        ///<summary>Compute the cumulative distribution function of packed single-precision (32-bit) floating-point elements in a using the normal distribution, and store the results in dst. (AVX512F)</summary>
        _MM512_CDFNORM_PS,
        ///<summary>Compute the cumulative distribution function of packed single-precision (32-bit) floating-point elements in a using the normal distribution, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CDFNORM_PS,
        ///<summary>Compute the inverse cumulative distribution function of packed double-precision (64-bit) floating-point elements in a using the normal distribution, and store the results in dst. (SSE)</summary>
        _MM_CDFNORMINV_PD,
        ///<summary>Compute the inverse cumulative distribution function of packed double-precision (64-bit) floating-point elements in a using the normal distribution, and store the results in dst. (AVX)</summary>
        _MM256_CDFNORMINV_PD,
        ///<summary>Compute the inverse cumulative distribution function of packed double-precision (64-bit) floating-point elements in a using the normal distribution, and store the results in dst. (AVX512F)</summary>
        _MM512_CDFNORMINV_PD,
        ///<summary>Compute the inverse cumulative distribution function of packed double-precision (64-bit) floating-point elements in a using the normal distribution, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CDFNORMINV_PD,
        ///<summary>Compute the inverse cumulative distribution function of packed single-precision (32-bit) floating-point elements in a using the normal distribution, and store the results in dst. (SSE)</summary>
        _MM_CDFNORMINV_PS,
        ///<summary>Compute the inverse cumulative distribution function of packed single-precision (32-bit) floating-point elements in a using the normal distribution, and store the results in dst. (AVX)</summary>
        _MM256_CDFNORMINV_PS,
        ///<summary>Compute the inverse cumulative distribution function of packed single-precision (32-bit) floating-point elements in a using the normal distribution, and store the results in dst. (AVX512F)</summary>
        _MM512_CDFNORMINV_PS,
        ///<summary>Compute the inverse cumulative distribution function of packed single-precision (32-bit) floating-point elements in a using the normal distribution, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CDFNORMINV_PS,
        ///<summary>Round the packed double-precision (64-bit) floating-point elements in a up to an integer value, and store the results as packed double-precision floating-point elements in dst. (SSE4.1)</summary>
        _MM_CEIL_PD,
        ///<summary>Round the packed double-precision (64-bit) floating-point elements in a up to an integer value, and store the results as packed double-precision floating-point elements in dst. (AVX)</summary>
        _MM256_CEIL_PD,
        ///<summary>Round the packed double-precision (64-bit) floating-point elements in a up to an integer value, and store the results as packed double-precision floating-point elements in dst. (AVX512F)</summary>
        _MM512_CEIL_PD,
        ///<summary>Round the packed double-precision (64-bit) floating-point elements in a up to an integer value, and store the results as packed double-precision floating-point elements in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CEIL_PD,
        ///<summary>Round the packed single-precision (32-bit) floating-point elements in a up to an integer value, and store the results as packed single-precision floating-point elements in dst. (SSE4.1)</summary>
        _MM_CEIL_PS,
        ///<summary>Round the packed single-precision (32-bit) floating-point elements in a up to an integer value, and store the results as packed single-precision floating-point elements in dst. (AVX)</summary>
        _MM256_CEIL_PS,
        ///<summary>Round the packed single-precision (32-bit) floating-point elements in a up to an integer value, and store the results as packed single-precision floating-point elements in dst. (AVX512F)</summary>
        _MM512_CEIL_PS,
        ///<summary>Round the packed single-precision (32-bit) floating-point elements in a up to an integer value, and store the results as packed single-precision floating-point elements in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CEIL_PS,
        ///<summary>Round the lower double-precision (64-bit) floating-point element in b up to an integer value, store the result as a double-precision floating-point element in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE4.1)</summary>
        _MM_CEIL_SD,
        ///<summary>Round the lower single-precision (32-bit) floating-point element in b up to an integer value, store the result as a single-precision floating-point element in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE4.1)</summary>
        _MM_CEIL_SS,
        ///<summary>Compute the exponential value of e raised to the power of packed complex single-precision (32-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_CEXP_PS,
        ///<summary>Compute the exponential value of e raised to the power of packed complex single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_CEXP_PS,
        ///<summary>Evicts the cache line containing the address ptr from cache level level (can be either 0 or 1). (KNCNI)</summary>
        _MM_CLEVICT,
        ///<summary>Invalidate and flush the cache line that contains p from all levels of the cache hierarchy. (SSE2)</summary>
        _MM_CLFLUSH,
        ///<summary>Invalidate and flush the cache line that contains p from all levels of the cache hierarchy. (CLFLUSHOPT)</summary>
        _MM_CLFLUSHOPT,
        ///<summary>Perform a carry-less multiplication of two 64-bit integers, selected from a and b according to imm8, and store the results in dst. (PCLMULQDQ)</summary>
        _MM_CLMULEPI64_SI128,
        ///<summary>Compute the natural logarithm of packed complex single-precision (32-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_CLOG_PS,
        ///<summary>Compute the natural logarithm of packed complex single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_CLOG_PS,
        ///<summary>Compare packed 16-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMP_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMP_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMP_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMP_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMP_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMP_EPI16_MASK,
        ///<summary>Compare packed 32-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMP_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMP_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMP_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMP_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMP_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMP_EPI32_MASK,
        ///<summary>Compare packed 64-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMP_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMP_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMP_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMP_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMP_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMP_EPI64_MASK,
        ///<summary>Compare packed 8-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMP_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMP_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMP_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMP_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMP_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMP_EPI8_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMP_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMP_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMP_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMP_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMP_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMP_EPU16_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMP_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMP_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMP_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMP_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMP_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMP_EPU32_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMP_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMP_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMP_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMP_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMP_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMP_EPU64_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMP_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMP_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMP_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMP_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMP_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b based on the comparison operand specified by imm8, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMP_EPU8_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in dst. (AVX)</summary>
        _MM_CMP_PD,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in dst. (AVX)</summary>
        _MM256_CMP_PD,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMP_PD_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMP_PD_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMP_PD_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMP_PD_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMP_PD_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMP_PD_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in dst. (AVX)</summary>
        _MM_CMP_PS,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in dst. (AVX)</summary>
        _MM256_CMP_PS,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMP_PS_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMP_PS_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMP_PS_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMP_PS_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMP_PS_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMP_PS_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. 	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F, KNCNI)</summary>
        _MM512_CMP_ROUND_PD_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMP_ROUND_PD_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k. 	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F, KNCNI)</summary>
        _MM512_CMP_ROUND_PS_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b based on the comparison operand specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMP_ROUND_PS_MASK,
        ///<summary>Compare the lower double-precision (64-bit) floating-point element in a and b based on the comparison operand specified by imm8, and store the result in mask vector k. 	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM_CMP_ROUND_SD_MASK,
        ///<summary>Compare the lower double-precision (64-bit) floating-point element in a and b based on the comparison operand specified by imm8, and store the result in mask vector k using zeromask k1 (the element is zeroed out when mask bit 0 is not set). 	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM_MASK_CMP_ROUND_SD_MASK,
        ///<summary>Compare the lower single-precision (32-bit) floating-point element in a and b based on the comparison operand specified by imm8, and store the result in mask vector k. 	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM_CMP_ROUND_SS_MASK,
        ///<summary>Compare the lower single-precision (32-bit) floating-point element in a and b based on the comparison operand specified by imm8, and store the result in mask vector k using zeromask k1 (the element is zeroed out when mask bit 0 is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM_MASK_CMP_ROUND_SS_MASK,
        ///<summary>Compare the lower double-precision (64-bit) floating-point element in a and b based on the comparison operand specified by imm8, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (AVX)</summary>
        _MM_CMP_SD,
        ///<summary>Compare the lower double-precision (64-bit) floating-point element in a and b based on the comparison operand specified by imm8, and store the result in mask vector k. (AVX512F)</summary>
        _MM_CMP_SD_MASK,
        ///<summary>Compare the lower double-precision (64-bit) floating-point element in a and b based on the comparison operand specified by imm8, and store the result in mask vector k using zeromask k1 (the element is zeroed out when mask bit 0 is not set). (AVX512F)</summary>
        _MM_MASK_CMP_SD_MASK,
        ///<summary>Compare the lower single-precision (32-bit) floating-point element in a and b based on the comparison operand specified by imm8, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (AVX)</summary>
        _MM_CMP_SS,
        ///<summary>Compare the lower single-precision (32-bit) floating-point element in a and b based on the comparison operand specified by imm8, and store the result in mask vector k. (AVX512F)</summary>
        _MM_CMP_SS_MASK,
        ///<summary>Compare the lower single-precision (32-bit) floating-point element in a and b based on the comparison operand specified by imm8, and store the result in mask vector k using zeromask k1 (the element is zeroed out when mask bit 0 is not set). (AVX512F)</summary>
        _MM_MASK_CMP_SS_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for equality, and store the results in dst. (SSE2)</summary>
        _MM_CMPEQ_EPI16,
        ///<summary>Compare packed 16-bit integers in a and b for equality, and store the results in dst. (AVX2)</summary>
        _MM256_CMPEQ_EPI16,
        ///<summary>Compare packed 16-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPEQ_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPEQ_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPEQ_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPEQ_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for equality, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPEQ_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPEQ_EPI16_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for equality, and store the results in dst. (SSE2)</summary>
        _MM_CMPEQ_EPI32,
        ///<summary>Compare packed 32-bit integers in a and b for equality, and store the results in dst. (AVX2)</summary>
        _MM256_CMPEQ_EPI32,
        ///<summary>Compare packed 32-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPEQ_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPEQ_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPEQ_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPEQ_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for equality, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPEQ_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPEQ_EPI32_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for equality, and store the results in dst. (SSE4.1)</summary>
        _MM_CMPEQ_EPI64,
        ///<summary>Compare packed 64-bit integers in a and b for equality, and store the results in dst. (AVX2)</summary>
        _MM256_CMPEQ_EPI64,
        ///<summary>Compare packed 64-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPEQ_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPEQ_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPEQ_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPEQ_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for equality, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMPEQ_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMPEQ_EPI64_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for equality, and store the results in dst. (SSE2)</summary>
        _MM_CMPEQ_EPI8,
        ///<summary>Compare packed 8-bit integers in a and b for equality, and store the results in dst. (AVX2)</summary>
        _MM256_CMPEQ_EPI8,
        ///<summary>Compare packed 8-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPEQ_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for equality, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPEQ_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPEQ_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for equality, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPEQ_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for equality, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPEQ_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for equality, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPEQ_EPI8_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPEQ_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPEQ_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPEQ_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPEQ_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for equality, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPEQ_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPEQ_EPU16_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPEQ_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPEQ_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPEQ_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPEQ_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for equality, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPEQ_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPEQ_EPU32_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPEQ_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPEQ_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPEQ_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPEQ_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for equality, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMPEQ_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for equality, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMPEQ_EPU64_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPEQ_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for equality, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPEQ_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for equality, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPEQ_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for equality, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPEQ_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for equality, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPEQ_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for equality, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPEQ_EPU8_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for equality, and store the results in dst. (SSE2)</summary>
        _MM_CMPEQ_PD,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for equality, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPEQ_PD_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for equality, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPEQ_PD_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for equality, and store the results in dst. (MMX)</summary>
        _MM_CMPEQ_PI16,
        ///<summary>Compare packed 32-bit integers in a and b for equality, and store the results in dst. (MMX)</summary>
        _MM_CMPEQ_PI32,
        ///<summary>Compare packed 8-bit integers in a and b for equality, and store the results in dst. (MMX)</summary>
        _MM_CMPEQ_PI8,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for equality, and store the results in dst. (SSE)</summary>
        _MM_CMPEQ_PS,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for equality, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPEQ_PS_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for equality, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPEQ_PS_MASK,
        ///<summary>Compare the lower double-precision (64-bit) floating-point elements in a and b for equality, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CMPEQ_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point elements in a and b for equality, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CMPEQ_SS,
        ///<summary>Compare packed strings in a and b with lengths la and lb using the control in imm8, and returns 1 if b did not contain a null character and the resulting mask was zero, and 0 otherwise. 	imm can be a combination of:    _SIDD_UBYTE_OPS                // unsigned 8-bit characters     _SIDD_UWORD_OPS                // unsigned 16-bit characters     _SIDD_SBYTE_OPS                // signed 8-bit characters     _SIDD_SWORD_OPS                // signed 16-bit characters     _SIDD_CMP_EQUAL_ANY            // compare equal any     _SIDD_CMP_RANGES               // compare ranges     _SIDD_CMP_EQUAL_EACH           // compare equal each     _SIDD_CMP_EQUAL_ORDERED        // compare equal ordered     _SIDD_NEGATIVE_POLARITY        // negate results     _SIDD_MASKED_NEGATIVE_POLARITY // negate results only before end of string     _SIDD_LEAST_SIGNIFICANT        // index only: return last significant bit     _SIDD_MOST_SIGNIFICANT         // index only: return most significant bit     _SIDD_BIT_MASK                 // mask only: return bit mask     _SIDD_UNIT_MASK                // mask only: return byte/word mask (SSE4.2)</summary>
        _MM_CMPESTRA,
        ///<summary>Compare packed strings in a and b with lengths la and lb using the control in imm8, and returns 1 if the resulting mask was non-zero, and 0 otherwise. 	imm can be a combination of:    _SIDD_UBYTE_OPS                // unsigned 8-bit characters     _SIDD_UWORD_OPS                // unsigned 16-bit characters     _SIDD_SBYTE_OPS                // signed 8-bit characters     _SIDD_SWORD_OPS                // signed 16-bit characters     _SIDD_CMP_EQUAL_ANY            // compare equal any     _SIDD_CMP_RANGES               // compare ranges     _SIDD_CMP_EQUAL_EACH           // compare equal each     _SIDD_CMP_EQUAL_ORDERED        // compare equal ordered     _SIDD_NEGATIVE_POLARITY        // negate results     _SIDD_MASKED_NEGATIVE_POLARITY // negate results only before end of string     _SIDD_LEAST_SIGNIFICANT        // index only: return last significant bit     _SIDD_MOST_SIGNIFICANT         // index only: return most significant bit     _SIDD_BIT_MASK                 // mask only: return bit mask     _SIDD_UNIT_MASK                // mask only: return byte/word mask (SSE4.2)</summary>
        _MM_CMPESTRC,
        ///<summary>Compare packed strings in a and b with lengths la and lb using the control in imm8, and store the generated index in dst. 	imm can be a combination of:    _SIDD_UBYTE_OPS                // unsigned 8-bit characters     _SIDD_UWORD_OPS                // unsigned 16-bit characters     _SIDD_SBYTE_OPS                // signed 8-bit characters     _SIDD_SWORD_OPS                // signed 16-bit characters     _SIDD_CMP_EQUAL_ANY            // compare equal any     _SIDD_CMP_RANGES               // compare ranges     _SIDD_CMP_EQUAL_EACH           // compare equal each     _SIDD_CMP_EQUAL_ORDERED        // compare equal ordered     _SIDD_NEGATIVE_POLARITY        // negate results     _SIDD_MASKED_NEGATIVE_POLARITY // negate results only before end of string     _SIDD_LEAST_SIGNIFICANT        // index only: return last significant bit     _SIDD_MOST_SIGNIFICANT         // index only: return most significant bit     _SIDD_BIT_MASK                 // mask only: return bit mask     _SIDD_UNIT_MASK                // mask only: return byte/word mask (SSE4.2)</summary>
        _MM_CMPESTRI,
        ///<summary>Compare packed strings in a and b with lengths la and lb using the control in imm8, and store the generated mask in dst. 	imm can be a combination of:    _SIDD_UBYTE_OPS                // unsigned 8-bit characters     _SIDD_UWORD_OPS                // unsigned 16-bit characters     _SIDD_SBYTE_OPS                // signed 8-bit characters     _SIDD_SWORD_OPS                // signed 16-bit characters     _SIDD_CMP_EQUAL_ANY            // compare equal any     _SIDD_CMP_RANGES               // compare ranges     _SIDD_CMP_EQUAL_EACH           // compare equal each     _SIDD_CMP_EQUAL_ORDERED        // compare equal ordered     _SIDD_NEGATIVE_POLARITY        // negate results     _SIDD_MASKED_NEGATIVE_POLARITY // negate results only before end of string     _SIDD_LEAST_SIGNIFICANT        // index only: return last significant bit     _SIDD_MOST_SIGNIFICANT         // index only: return most significant bit     _SIDD_BIT_MASK                 // mask only: return bit mask     _SIDD_UNIT_MASK                // mask only: return byte/word mask (SSE4.2)</summary>
        _MM_CMPESTRM,
        ///<summary>Compare packed strings in a and b with lengths la and lb using the control in imm8, and returns bit 0 of the resulting bit mask. 	imm can be a combination of:    _SIDD_UBYTE_OPS                // unsigned 8-bit characters     _SIDD_UWORD_OPS                // unsigned 16-bit characters     _SIDD_SBYTE_OPS                // signed 8-bit characters     _SIDD_SWORD_OPS                // signed 16-bit characters     _SIDD_CMP_EQUAL_ANY            // compare equal any     _SIDD_CMP_RANGES               // compare ranges     _SIDD_CMP_EQUAL_EACH           // compare equal each     _SIDD_CMP_EQUAL_ORDERED        // compare equal ordered     _SIDD_NEGATIVE_POLARITY        // negate results     _SIDD_MASKED_NEGATIVE_POLARITY // negate results only before end of string     _SIDD_LEAST_SIGNIFICANT        // index only: return last significant bit     _SIDD_MOST_SIGNIFICANT         // index only: return most significant bit     _SIDD_BIT_MASK                 // mask only: return bit mask     _SIDD_UNIT_MASK                // mask only: return byte/word mask (SSE4.2)</summary>
        _MM_CMPESTRO,
        ///<summary>Compare packed strings in a and b with lengths la and lb using the control in imm8, and returns 1 if any character in a was null, and 0 otherwise. 	imm can be a combination of:    _SIDD_UBYTE_OPS                // unsigned 8-bit characters     _SIDD_UWORD_OPS                // unsigned 16-bit characters     _SIDD_SBYTE_OPS                // signed 8-bit characters     _SIDD_SWORD_OPS                // signed 16-bit characters     _SIDD_CMP_EQUAL_ANY            // compare equal any     _SIDD_CMP_RANGES               // compare ranges     _SIDD_CMP_EQUAL_EACH           // compare equal each     _SIDD_CMP_EQUAL_ORDERED        // compare equal ordered     _SIDD_NEGATIVE_POLARITY        // negate results     _SIDD_MASKED_NEGATIVE_POLARITY // negate results only before end of string     _SIDD_LEAST_SIGNIFICANT        // index only: return last significant bit     _SIDD_MOST_SIGNIFICANT         // index only: return most significant bit     _SIDD_BIT_MASK                 // mask only: return bit mask     _SIDD_UNIT_MASK                // mask only: return byte/word mask (SSE4.2)</summary>
        _MM_CMPESTRS,
        ///<summary>Compare packed strings in a and b with lengths la and lb using the control in imm8, and returns 1 if any character in b was null, and 0 otherwise. 	imm can be a combination of:    _SIDD_UBYTE_OPS                // unsigned 8-bit characters     _SIDD_UWORD_OPS                // unsigned 16-bit characters     _SIDD_SBYTE_OPS                // signed 8-bit characters     _SIDD_SWORD_OPS                // signed 16-bit characters     _SIDD_CMP_EQUAL_ANY            // compare equal any     _SIDD_CMP_RANGES               // compare ranges     _SIDD_CMP_EQUAL_EACH           // compare equal each     _SIDD_CMP_EQUAL_ORDERED        // compare equal ordered     _SIDD_NEGATIVE_POLARITY        // negate results     _SIDD_MASKED_NEGATIVE_POLARITY // negate results only before end of string     _SIDD_LEAST_SIGNIFICANT        // index only: return last significant bit     _SIDD_MOST_SIGNIFICANT         // index only: return most significant bit     _SIDD_BIT_MASK                 // mask only: return bit mask     _SIDD_UNIT_MASK                // mask only: return byte/word mask (SSE4.2)</summary>
        _MM_CMPESTRZ,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPGE_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPGE_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPGE_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPGE_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPGE_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPGE_EPI16_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPGE_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPGE_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPGE_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPGE_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPGE_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPGE_EPI32_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPGE_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPGE_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPGE_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPGE_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMPGE_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMPGE_EPI64_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPGE_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPGE_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPGE_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPGE_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPGE_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPGE_EPI8_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPGE_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPGE_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPGE_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPGE_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPGE_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPGE_EPU16_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPGE_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPGE_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPGE_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPGE_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPGE_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPGE_EPU32_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPGE_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPGE_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPGE_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPGE_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMPGE_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMPGE_EPU64_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPGE_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPGE_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPGE_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPGE_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPGE_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for greater-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPGE_EPU8_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for greater-than-or-equal, and store the results in dst. (SSE2)</summary>
        _MM_CMPGE_PD,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for greater-than-or-equal, and store the results in dst. (SSE)</summary>
        _MM_CMPGE_PS,
        ///<summary>Compare the lower double-precision (64-bit) floating-point elements in a and b for greater-than-or-equal, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CMPGE_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point elements in a and b for greater-than-or-equal, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CMPGE_SS,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than, and store the results in dst. (SSE2)</summary>
        _MM_CMPGT_EPI16,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than, and store the results in dst. (AVX2)</summary>
        _MM256_CMPGT_EPI16,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPGT_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPGT_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPGT_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPGT_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPGT_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPGT_EPI16_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than, and store the results in dst. (SSE2)</summary>
        _MM_CMPGT_EPI32,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than, and store the results in dst. (AVX2)</summary>
        _MM256_CMPGT_EPI32,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPGT_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPGT_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPGT_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPGT_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPGT_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPGT_EPI32_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for greater-than, and store the results in dst. (SSE4.2)</summary>
        _MM_CMPGT_EPI64,
        ///<summary>Compare packed 64-bit integers in a and b for greater-than, and store the results in dst. (AVX2)</summary>
        _MM256_CMPGT_EPI64,
        ///<summary>Compare packed 64-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPGT_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPGT_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPGT_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPGT_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMPGT_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMPGT_EPI64_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than, and store the results in dst. (SSE2)</summary>
        _MM_CMPGT_EPI8,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than, and store the results in dst. (AVX2)</summary>
        _MM256_CMPGT_EPI8,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPGT_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPGT_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPGT_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPGT_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPGT_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPGT_EPI8_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPGT_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPGT_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPGT_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPGT_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPGT_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPGT_EPU16_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPGT_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPGT_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPGT_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPGT_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPGT_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPGT_EPU32_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPGT_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPGT_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPGT_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPGT_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMPGT_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for greater-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMPGT_EPU64_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPGT_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for greater-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPGT_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPGT_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for greater-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPGT_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for greater-than, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPGT_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for greater-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPGT_EPU8_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for greater-than, and store the results in dst. (SSE2)</summary>
        _MM_CMPGT_PD,
        ///<summary>Compare packed 16-bit integers in a and b for greater-than, and store the results in dst. (MMX)</summary>
        _MM_CMPGT_PI16,
        ///<summary>Compare packed 32-bit integers in a and b for greater-than, and store the results in dst. (MMX)</summary>
        _MM_CMPGT_PI32,
        ///<summary>Compare packed 8-bit integers in a and b for greater-than, and store the results in dst. (MMX)</summary>
        _MM_CMPGT_PI8,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for greater-than, and store the results in dst. (SSE)</summary>
        _MM_CMPGT_PS,
        ///<summary>Compare the lower double-precision (64-bit) floating-point elements in a and b for greater-than, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CMPGT_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point elements in a and b for greater-than, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CMPGT_SS,
        ///<summary>Compare packed strings with implicit lengths in a and b using the control in imm8, and returns 1 if b did not contain a null character and the resulting mask was zero, and 0 otherwise. 	imm can be a combination of:    _SIDD_UBYTE_OPS                // unsigned 8-bit characters     _SIDD_UWORD_OPS                // unsigned 16-bit characters     _SIDD_SBYTE_OPS                // signed 8-bit characters     _SIDD_SWORD_OPS                // signed 16-bit characters     _SIDD_CMP_EQUAL_ANY            // compare equal any     _SIDD_CMP_RANGES               // compare ranges     _SIDD_CMP_EQUAL_EACH           // compare equal each     _SIDD_CMP_EQUAL_ORDERED        // compare equal ordered     _SIDD_NEGATIVE_POLARITY        // negate results     _SIDD_MASKED_NEGATIVE_POLARITY // negate results only before end of string     _SIDD_LEAST_SIGNIFICANT        // index only: return last significant bit     _SIDD_MOST_SIGNIFICANT         // index only: return most significant bit     _SIDD_BIT_MASK                 // mask only: return bit mask     _SIDD_UNIT_MASK                // mask only: return byte/word mask (SSE4.2)</summary>
        _MM_CMPISTRA,
        ///<summary>Compare packed strings with implicit lengths in a and b using the control in imm8, and returns 1 if the resulting mask was non-zero, and 0 otherwise. 	imm can be a combination of:    _SIDD_UBYTE_OPS                // unsigned 8-bit characters     _SIDD_UWORD_OPS                // unsigned 16-bit characters     _SIDD_SBYTE_OPS                // signed 8-bit characters     _SIDD_SWORD_OPS                // signed 16-bit characters     _SIDD_CMP_EQUAL_ANY            // compare equal any     _SIDD_CMP_RANGES               // compare ranges     _SIDD_CMP_EQUAL_EACH           // compare equal each     _SIDD_CMP_EQUAL_ORDERED        // compare equal ordered     _SIDD_NEGATIVE_POLARITY        // negate results     _SIDD_MASKED_NEGATIVE_POLARITY // negate results only before end of string     _SIDD_LEAST_SIGNIFICANT        // index only: return last significant bit     _SIDD_MOST_SIGNIFICANT         // index only: return most significant bit     _SIDD_BIT_MASK                 // mask only: return bit mask     _SIDD_UNIT_MASK                // mask only: return byte/word mask (SSE4.2)</summary>
        _MM_CMPISTRC,
        ///<summary>Compare packed strings with implicit lengths in a and b using the control in imm8, and store the generated index in dst. 	imm can be a combination of:    _SIDD_UBYTE_OPS                // unsigned 8-bit characters     _SIDD_UWORD_OPS                // unsigned 16-bit characters     _SIDD_SBYTE_OPS                // signed 8-bit characters     _SIDD_SWORD_OPS                // signed 16-bit characters     _SIDD_CMP_EQUAL_ANY            // compare equal any     _SIDD_CMP_RANGES               // compare ranges     _SIDD_CMP_EQUAL_EACH           // compare equal each     _SIDD_CMP_EQUAL_ORDERED        // compare equal ordered     _SIDD_NEGATIVE_POLARITY        // negate results     _SIDD_MASKED_NEGATIVE_POLARITY // negate results only before end of string     _SIDD_LEAST_SIGNIFICANT        // index only: return last significant bit     _SIDD_MOST_SIGNIFICANT         // index only: return most significant bit     _SIDD_BIT_MASK                 // mask only: return bit mask     _SIDD_UNIT_MASK                // mask only: return byte/word mask (SSE4.2)</summary>
        _MM_CMPISTRI,
        ///<summary>Compare packed strings with implicit lengths in a and b using the control in imm8, and store the generated mask in dst. 	imm can be a combination of:    _SIDD_UBYTE_OPS                // unsigned 8-bit characters     _SIDD_UWORD_OPS                // unsigned 16-bit characters     _SIDD_SBYTE_OPS                // signed 8-bit characters     _SIDD_SWORD_OPS                // signed 16-bit characters     _SIDD_CMP_EQUAL_ANY            // compare equal any     _SIDD_CMP_RANGES               // compare ranges     _SIDD_CMP_EQUAL_EACH           // compare equal each     _SIDD_CMP_EQUAL_ORDERED        // compare equal ordered     _SIDD_NEGATIVE_POLARITY        // negate results     _SIDD_MASKED_NEGATIVE_POLARITY // negate results only before end of string     _SIDD_LEAST_SIGNIFICANT        // index only: return last significant bit     _SIDD_MOST_SIGNIFICANT         // index only: return most significant bit     _SIDD_BIT_MASK                 // mask only: return bit mask     _SIDD_UNIT_MASK                // mask only: return byte/word mask (SSE4.2)</summary>
        _MM_CMPISTRM,
        ///<summary>Compare packed strings with implicit lengths in a and b using the control in imm8, and returns bit 0 of the resulting bit mask. 	imm can be a combination of:    _SIDD_UBYTE_OPS                // unsigned 8-bit characters     _SIDD_UWORD_OPS                // unsigned 16-bit characters     _SIDD_SBYTE_OPS                // signed 8-bit characters     _SIDD_SWORD_OPS                // signed 16-bit characters     _SIDD_CMP_EQUAL_ANY            // compare equal any     _SIDD_CMP_RANGES               // compare ranges     _SIDD_CMP_EQUAL_EACH           // compare equal each     _SIDD_CMP_EQUAL_ORDERED        // compare equal ordered     _SIDD_NEGATIVE_POLARITY        // negate results     _SIDD_MASKED_NEGATIVE_POLARITY // negate results only before end of string     _SIDD_LEAST_SIGNIFICANT        // index only: return last significant bit     _SIDD_MOST_SIGNIFICANT         // index only: return most significant bit     _SIDD_BIT_MASK                 // mask only: return bit mask     _SIDD_UNIT_MASK                // mask only: return byte/word mask (SSE4.2)</summary>
        _MM_CMPISTRO,
        ///<summary>Compare packed strings with implicit lengths in a and b using the control in imm8, and returns 1 if any character in a was null, and 0 otherwise. 	imm can be a combination of:    _SIDD_UBYTE_OPS                // unsigned 8-bit characters     _SIDD_UWORD_OPS                // unsigned 16-bit characters     _SIDD_SBYTE_OPS                // signed 8-bit characters     _SIDD_SWORD_OPS                // signed 16-bit characters     _SIDD_CMP_EQUAL_ANY            // compare equal any     _SIDD_CMP_RANGES               // compare ranges     _SIDD_CMP_EQUAL_EACH           // compare equal each     _SIDD_CMP_EQUAL_ORDERED        // compare equal ordered     _SIDD_NEGATIVE_POLARITY        // negate results     _SIDD_MASKED_NEGATIVE_POLARITY // negate results only before end of string     _SIDD_LEAST_SIGNIFICANT        // index only: return last significant bit     _SIDD_MOST_SIGNIFICANT         // index only: return most significant bit     _SIDD_BIT_MASK                 // mask only: return bit mask     _SIDD_UNIT_MASK                // mask only: return byte/word mask (SSE4.2)</summary>
        _MM_CMPISTRS,
        ///<summary>Compare packed strings with implicit lengths in a and b using the control in imm8, and returns 1 if any character in b was null, and 0 otherwise. 	imm can be a combination of:    _SIDD_UBYTE_OPS                // unsigned 8-bit characters     _SIDD_UWORD_OPS                // unsigned 16-bit characters     _SIDD_SBYTE_OPS                // signed 8-bit characters     _SIDD_SWORD_OPS                // signed 16-bit characters     _SIDD_CMP_EQUAL_ANY            // compare equal any     _SIDD_CMP_RANGES               // compare ranges     _SIDD_CMP_EQUAL_EACH           // compare equal each     _SIDD_CMP_EQUAL_ORDERED        // compare equal ordered     _SIDD_NEGATIVE_POLARITY        // negate results     _SIDD_MASKED_NEGATIVE_POLARITY // negate results only before end of string     _SIDD_LEAST_SIGNIFICANT        // index only: return last significant bit     _SIDD_MOST_SIGNIFICANT         // index only: return most significant bit     _SIDD_BIT_MASK                 // mask only: return bit mask     _SIDD_UNIT_MASK                // mask only: return byte/word mask (SSE4.2)</summary>
        _MM_CMPISTRZ,
        ///<summary>Compare packed 16-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPLE_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPLE_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPLE_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPLE_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPLE_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPLE_EPI16_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPLE_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPLE_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPLE_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPLE_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPLE_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPLE_EPI32_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPLE_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPLE_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPLE_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPLE_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMPLE_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMPLE_EPI64_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPLE_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for less-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPLE_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPLE_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for less-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPLE_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPLE_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for less-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPLE_EPI8_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPLE_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPLE_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPLE_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPLE_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPLE_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPLE_EPU16_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPLE_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPLE_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPLE_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPLE_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPLE_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPLE_EPU32_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPLE_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPLE_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPLE_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPLE_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMPLE_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMPLE_EPU64_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPLE_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for less-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPLE_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPLE_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for less-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPLE_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPLE_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for less-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPLE_EPU8_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for less-than-or-equal, and store the results in dst. (SSE2)</summary>
        _MM_CMPLE_PD,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPLE_PD_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for less-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPLE_PD_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for less-than-or-equal, and store the results in dst. (SSE)</summary>
        _MM_CMPLE_PS,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for less-than-or-equal, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPLE_PS_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for less-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPLE_PS_MASK,
        ///<summary>Compare the lower double-precision (64-bit) floating-point elements in a and b for less-than-or-equal, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CMPLE_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point elements in a and b for less-than-or-equal, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CMPLE_SS,
        ///<summary>Compare packed 16-bit integers in a and b for less-than, and store the results in dst. Note: This intrinsic emits the pcmpgtw instruction with the order of the operands switched. (SSE2)</summary>
        _MM_CMPLT_EPI16,
        ///<summary>Compare packed 16-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPLT_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPLT_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPLT_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPLT_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPLT_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPLT_EPI16_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for less-than, and store the results in dst. Note: This intrinsic emits the pcmpgtd instruction with the order of the operands switched. (SSE2)</summary>
        _MM_CMPLT_EPI32,
        ///<summary>Compare packed 32-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPLT_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPLT_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPLT_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPLT_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMPLT_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for less-than, and store the results in mask vector k. (KNCNI)</summary>
        //_MM512_CMPLT_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMPLT_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (KNCNI)</summary>
        //_MM512_MASK_CMPLT_EPI32_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPLT_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPLT_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPLT_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPLT_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMPLT_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMPLT_EPI64_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for less-than, and store the results in dst. Note: This intrinsic emits the pcmpgtb instruction with the order of the operands switched. (SSE2)</summary>
        _MM_CMPLT_EPI8,
        ///<summary>Compare packed 8-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPLT_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for less-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPLT_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPLT_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for less-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPLT_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPLT_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for less-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPLT_EPI8_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPLT_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPLT_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPLT_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPLT_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPLT_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPLT_EPU16_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPLT_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPLT_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPLT_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPLT_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPLT_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for less-than-or-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPLT_EPU32_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPLT_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPLT_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPLT_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPLT_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMPLT_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for less-than, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMPLT_EPU64_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPLT_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for less-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPLT_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPLT_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for less-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPLT_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for less-than, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPLT_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for less-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPLT_EPU8_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for less-than, and store the results in dst. (SSE2)</summary>
        _MM_CMPLT_PD,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for less-than, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPLT_PD_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for less-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPLT_PD_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for less-than, and store the results in dst. (SSE)</summary>
        _MM_CMPLT_PS,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for less-than, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPLT_PS_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for less-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPLT_PS_MASK,
        ///<summary>Compare the lower double-precision (64-bit) floating-point elements in a and b for less-than, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CMPLT_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point elements in a and b for less-than, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CMPLT_SS,
        ///<summary>Compare packed 16-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPNEQ_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPNEQ_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPNEQ_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPNEQ_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPNEQ_EPI16_MASK,
        ///<summary>Compare packed 16-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPNEQ_EPI16_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPNEQ_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPNEQ_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPNEQ_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPNEQ_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPNEQ_EPI32_MASK,
        ///<summary>Compare packed 32-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPNEQ_EPI32_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPNEQ_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPNEQ_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPNEQ_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPNEQ_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMPNEQ_EPI64_MASK,
        ///<summary>Compare packed 64-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMPNEQ_EPI64_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPNEQ_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for not-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPNEQ_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPNEQ_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for not-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPNEQ_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPNEQ_EPI8_MASK,
        ///<summary>Compare packed 8-bit integers in a and b for not-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPNEQ_EPI8_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPNEQ_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPNEQ_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPNEQ_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPNEQ_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPNEQ_EPU16_MASK,
        ///<summary>Compare packed unsigned 16-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPNEQ_EPU16_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPNEQ_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPNEQ_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPNEQ_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPNEQ_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPNEQ_EPU32_MASK,
        ///<summary>Compare packed unsigned 32-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPNEQ_EPU32_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM_CMPNEQ_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CMPNEQ_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512F)</summary>
        _MM256_CMPNEQ_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CMPNEQ_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512F)</summary>
        _MM512_CMPNEQ_EPU64_MASK,
        ///<summary>Compare packed unsigned 64-bit integers in a and b for not-equal, and store the results in mask vector k1 using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CMPNEQ_EPU64_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM_CMPNEQ_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for not-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CMPNEQ_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512VL, AVX512BW)</summary>
        _MM256_CMPNEQ_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for not-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CMPNEQ_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for not-equal, and store the results in mask vector k. (AVX512BW)</summary>
        _MM512_CMPNEQ_EPU8_MASK,
        ///<summary>Compare packed unsigned 8-bit integers in a and b for not-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CMPNEQ_EPU8_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for not-equal, and store the results in dst. (SSE2)</summary>
        _MM_CMPNEQ_PD,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for not-equal, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPNEQ_PD_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for not-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPNEQ_PD_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for not-equal, and store the results in dst. (SSE)</summary>
        _MM_CMPNEQ_PS,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for not-equal, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPNEQ_PS_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for not-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPNEQ_PS_MASK,
        ///<summary>Compare the lower double-precision (64-bit) floating-point elements in a and b for not-equal, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CMPNEQ_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point elements in a and b for not-equal, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CMPNEQ_SS,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for not-greater-than-or-equal, and store the results in dst. (SSE2)</summary>
        _MM_CMPNGE_PD,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for not-greater-than-or-equal, and store the results in dst. (SSE)</summary>
        _MM_CMPNGE_PS,
        ///<summary>Compare the lower double-precision (64-bit) floating-point elements in a and b for not-greater-than-or-equal, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CMPNGE_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point elements in a and b for not-greater-than-or-equal, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CMPNGE_SS,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for not-greater-than, and store the results in dst. (SSE2)</summary>
        _MM_CMPNGT_PD,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for not-greater-than, and store the results in dst. (SSE)</summary>
        _MM_CMPNGT_PS,
        ///<summary>Compare the lower double-precision (64-bit) floating-point elements in a and b for not-greater-than, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CMPNGT_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point elements in a and b for not-greater-than, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CMPNGT_SS,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for not-less-than-or-equal, and store the results in dst. (SSE2)</summary>
        _MM_CMPNLE_PD,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for not-less-than-or-equal, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPNLE_PD_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for not-less-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPNLE_PD_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for not-less-than-or-equal, and store the results in dst. (SSE)</summary>
        _MM_CMPNLE_PS,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for not-less-than-or-equal, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPNLE_PS_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for not-less-than-or-equal, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPNLE_PS_MASK,
        ///<summary>Compare the lower double-precision (64-bit) floating-point elements in a and b for not-less-than-or-equal, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CMPNLE_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point elements in a and b for not-less-than-or-equal, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CMPNLE_SS,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for not-less-than, and store the results in dst. (SSE2)</summary>
        _MM_CMPNLT_PD,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for not-less-than, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPNLT_PD_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b for not-less-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPNLT_PD_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for not-less-than, and store the results in dst. (SSE)</summary>
        _MM_CMPNLT_PS,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for not-less-than, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPNLT_PS_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b for not-less-than, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPNLT_PS_MASK,
        ///<summary>Compare the lower double-precision (64-bit) floating-point elements in a and b for not-less-than, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CMPNLT_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point elements in a and b for not-less-than, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CMPNLT_SS,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b to see if neither is NaN, and store the results in dst. (SSE2)</summary>
        _MM_CMPORD_PD,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b to see if neither is NaN, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPORD_PD_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b to see if neither is NaN, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPORD_PD_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b to see if neither is NaN, and store the results in dst. (SSE)</summary>
        _MM_CMPORD_PS,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b to see if neither is NaN, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPORD_PS_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b to see if neither is NaN, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPORD_PS_MASK,
        ///<summary>Compare the lower double-precision (64-bit) floating-point elements in a and b to see if neither is NaN, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CMPORD_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point elements in a and b to see if neither is NaN, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CMPORD_SS,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b to see if either is NaN, and store the results in dst. (SSE2)</summary>
        _MM_CMPUNORD_PD,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b to see if either is NaN, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPUNORD_PD_MASK,
        ///<summary>Compare packed double-precision (64-bit) floating-point elements in a and b to see if either is NaN, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPUNORD_PD_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b to see if either is NaN, and store the results in dst. (SSE)</summary>
        _MM_CMPUNORD_PS,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b to see if either is NaN, and store the results in mask vector k. (AVX512F, KNCNI)</summary>
        _MM512_CMPUNORD_PS_MASK,
        ///<summary>Compare packed single-precision (32-bit) floating-point elements in a and b to see if either is NaN, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CMPUNORD_PS_MASK,
        ///<summary>Compare the lower double-precision (64-bit) floating-point elements in a and b to see if either is NaN, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CMPUNORD_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point elements in a and b to see if either is NaN, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CMPUNORD_SS,
        ///<summary>Compare the lower double-precision (64-bit) floating-point element in a and b based on the comparison operand specified by imm8, and return the boolean result (0 or 1). 	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM_COMI_ROUND_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point element in a and b based on the comparison operand specified by imm8, and return the boolean result (0 or 1). 	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM_COMI_ROUND_SS,
        ///<summary>Compare the lower double-precision (64-bit) floating-point element in a and b for equality, and return the boolean result (0 or 1). (SSE2)</summary>
        _MM_COMIEQ_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point element in a and b for equality, and return the boolean result (0 or 1). (SSE)</summary>
        _MM_COMIEQ_SS,
        ///<summary>Compare the lower double-precision (64-bit) floating-point element in a and b for greater-than-or-equal, and return the boolean result (0 or 1). (SSE2)</summary>
        _MM_COMIGE_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point element in a and b for greater-than-or-equal, and return the boolean result (0 or 1). (SSE)</summary>
        _MM_COMIGE_SS,
        ///<summary>Compare the lower double-precision (64-bit) floating-point element in a and b for greater-than, and return the boolean result (0 or 1). (SSE2)</summary>
        _MM_COMIGT_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point element in a and b for greater-than, and return the boolean result (0 or 1). (SSE)</summary>
        _MM_COMIGT_SS,
        ///<summary>Compare the lower double-precision (64-bit) floating-point element in a and b for less-than-or-equal, and return the boolean result (0 or 1). (SSE2)</summary>
        _MM_COMILE_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point element in a and b for less-than-or-equal, and return the boolean result (0 or 1). (SSE)</summary>
        _MM_COMILE_SS,
        ///<summary>Compare the lower double-precision (64-bit) floating-point element in a and b for less-than, and return the boolean result (0 or 1). (SSE2)</summary>
        _MM_COMILT_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point element in a and b for less-than, and return the boolean result (0 or 1). (SSE)</summary>
        _MM_COMILT_SS,
        ///<summary>Compare the lower double-precision (64-bit) floating-point element in a and b for not-equal, and return the boolean result (0 or 1). (SSE2)</summary>
        _MM_COMINEQ_SD,
        ///<summary>Compare the lower single-precision (32-bit) floating-point element in a and b for not-equal, and return the boolean result (0 or 1). (SSE)</summary>
        _MM_COMINEQ_SS,
        ///<summary>Contiguously store the active 32-bit integers in a (those with their respective bit set in writemask k) to dst, and pass through the remaining elements from src. (AVX512VL, AVX512F)</summary>
        _MM_MASK_COMPRESS_EPI32,
        ///<summary>Contiguously store the active 32-bit integers in a (those with their respective bit set in zeromask k) to dst, and set the remaining elements to zero. (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_COMPRESS_EPI32,
        ///<summary>Contiguously store the active 32-bit integers in a (those with their respective bit set in writemask k) to dst, and pass through the remaining elements from src. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_COMPRESS_EPI32,
        ///<summary>Contiguously store the active 32-bit integers in a (those with their respective bit set in zeromask k) to dst, and set the remaining elements to zero. (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_COMPRESS_EPI32,
        ///<summary>Contiguously store the active 32-bit integers in a (those with their respective bit set in writemask k) to dst, and pass through the remaining elements from src. (AVX512F)</summary>
        _MM512_MASK_COMPRESS_EPI32,
        ///<summary>Contiguously store the active 32-bit integers in a (those with their respective bit set in zeromask k) to dst, and set the remaining elements to zero. (AVX512F)</summary>
        _MM512_MASKZ_COMPRESS_EPI32,
        ///<summary>Contiguously store the active 64-bit integers in a (those with their respective bit set in writemask k) to dst, and pass through the remaining elements from src. (AVX512VL, AVX512F)</summary>
        _MM_MASK_COMPRESS_EPI64,
        ///<summary>Contiguously store the active 64-bit integers in a (those with their respective bit set in zeromask k) to dst, and set the remaining elements to zero. (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_COMPRESS_EPI64,
        ///<summary>Contiguously store the active 64-bit integers in a (those with their respective bit set in writemask k) to dst, and pass through the remaining elements from src. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_COMPRESS_EPI64,
        ///<summary>Contiguously store the active 64-bit integers in a (those with their respective bit set in zeromask k) to dst, and set the remaining elements to zero. (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_COMPRESS_EPI64,
        ///<summary>Contiguously store the active 64-bit integers in a (those with their respective bit set in writemask k) to dst, and pass through the remaining elements from src. (AVX512F)</summary>
        _MM512_MASK_COMPRESS_EPI64,
        ///<summary>Contiguously store the active 64-bit integers in a (those with their respective bit set in zeromask k) to dst, and set the remaining elements to zero. (AVX512F)</summary>
        _MM512_MASKZ_COMPRESS_EPI64,
        ///<summary>Contiguously store the active double-precision (64-bit) floating-point elements in a (those with their respective bit set in writemask k) to dst, and pass through the remaining elements from src. (AVX512VL, AVX512F)</summary>
        _MM_MASK_COMPRESS_PD,
        ///<summary>Contiguously store the active double-precision (64-bit) floating-point elements in a (those with their respective bit set in zeromask k) to dst, and set the remaining elements to zero. (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_COMPRESS_PD,
        ///<summary>Contiguously store the active double-precision (64-bit) floating-point elements in a (those with their respective bit set in writemask k) to dst, and pass through the remaining elements from src. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_COMPRESS_PD,
        ///<summary>Contiguously store the active double-precision (64-bit) floating-point elements in a (those with their respective bit set in zeromask k) to dst, and set the remaining elements to zero. (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_COMPRESS_PD,
        ///<summary>Contiguously store the active double-precision (64-bit) floating-point elements in a (those with their respective bit set in writemask k) to dst, and pass through the remaining elements from src. (AVX512F)</summary>
        _MM512_MASK_COMPRESS_PD,
        ///<summary>Contiguously store the active double-precision (64-bit) floating-point elements in a (those with their respective bit set in zeromask k) to dst, and set the remaining elements to zero. (AVX512F)</summary>
        _MM512_MASKZ_COMPRESS_PD,
        ///<summary>Contiguously store the active single-precision (32-bit) floating-point elements in a (those with their respective bit set in writemask k) to dst, and pass through the remaining elements from src. (AVX512VL, AVX512F)</summary>
        _MM_MASK_COMPRESS_PS,
        ///<summary>Contiguously store the active single-precision (32-bit) floating-point elements in a (those with their respective bit set in zeromask k) to dst, and set the remaining elements to zero. (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_COMPRESS_PS,
        ///<summary>Contiguously store the active single-precision (32-bit) floating-point elements in a (those with their respective bit set in writemask k) to dst, and pass through the remaining elements from src. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_COMPRESS_PS,
        ///<summary>Contiguously store the active single-precision (32-bit) floating-point elements in a (those with their respective bit set in zeromask k) to dst, and set the remaining elements to zero. (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_COMPRESS_PS,
        ///<summary>Contiguously store the active single-precision (32-bit) floating-point elements in a (those with their respective bit set in writemask k) to dst, and pass through the remaining elements from src. (AVX512F)</summary>
        _MM512_MASK_COMPRESS_PS,
        ///<summary>Contiguously store the active single-precision (32-bit) floating-point elements in a (those with their respective bit set in zeromask k) to dst, and set the remaining elements to zero. (AVX512F)</summary>
        _MM512_MASKZ_COMPRESS_PS,
        ///<summary>Contiguously store the active 32-bit integers in a (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_COMPRESSSTOREU_EPI32,
        ///<summary>Contiguously store the active 32-bit integers in a (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_COMPRESSSTOREU_EPI32,
        ///<summary>Contiguously store the active 32-bit integers in a (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_COMPRESSSTOREU_EPI32,
        ///<summary>Contiguously store the active 64-bit integers in a (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_COMPRESSSTOREU_EPI64,
        ///<summary>Contiguously store the active 64-bit integers in a (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_COMPRESSSTOREU_EPI64,
        ///<summary>Contiguously store the active 64-bit integers in a (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_COMPRESSSTOREU_EPI64,
        ///<summary>Contiguously store the active double-precision (64-bit) floating-point elements in a (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_COMPRESSSTOREU_PD,
        ///<summary>Contiguously store the active double-precision (64-bit) floating-point elements in a (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_COMPRESSSTOREU_PD,
        ///<summary>Contiguously store the active double-precision (64-bit) floating-point elements in a (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_COMPRESSSTOREU_PD,
        ///<summary>Contiguously store the active single-precision (32-bit) floating-point elements in a (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_COMPRESSSTOREU_PS,
        ///<summary>Contiguously store the active single-precision (32-bit) floating-point elements in a (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_COMPRESSSTOREU_PS,
        ///<summary>Contiguously store the active single-precision (32-bit) floating-point elements in a (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_COMPRESSSTOREU_PS,
        ///<summary>Test each 32-bit element of a for equality with all other elements in a closer to the least significant bit. Each element's comparison forms a zero extended bit vector in dst. (AVX512VL, AVX512CD)</summary>
        _MM_CONFLICT_EPI32,
        ///<summary>Test each 32-bit element of a for equality with all other elements in a closer to the least significant bit using writemask k (elements are copied from src when the corresponding mask bit is not set). Each element's comparison forms a zero extended bit vector in dst. (AVX512VL, AVX512CD)</summary>
        _MM_MASK_CONFLICT_EPI32,
        ///<summary>Test each 32-bit element of a for equality with all other elements in a closer to the least significant bit using zeromask k (elements are zeroed out when the corresponding mask bit is not set). Each element's comparison forms a zero extended bit vector in dst. (AVX512VL, AVX512CD)</summary>
        _MM_MASKZ_CONFLICT_EPI32,
        ///<summary>Test each 32-bit element of a for equality with all other elements in a closer to the least significant bit. Each element's comparison forms a zero extended bit vector in dst. (AVX512VL, AVX512CD)</summary>
        _MM256_CONFLICT_EPI32,
        ///<summary>Test each 32-bit element of a for equality with all other elements in a closer to the least significant bit using writemask k (elements are copied from src when the corresponding mask bit is not set). Each element's comparison forms a zero extended bit vector in dst. (AVX512VL, AVX512CD)</summary>
        _MM256_MASK_CONFLICT_EPI32,
        ///<summary>Test each 32-bit element of a for equality with all other elements in a closer to the least significant bit using zeromask k (elements are zeroed out when the corresponding mask bit is not set). Each element's comparison forms a zero extended bit vector in dst. (AVX512VL, AVX512CD)</summary>
        _MM256_MASKZ_CONFLICT_EPI32,
        ///<summary>Test each 32-bit element of a for equality with all other elements in a closer to the least significant bit. Each element's comparison forms a zero extended bit vector in dst. (AVX512CD)</summary>
        _MM512_CONFLICT_EPI32,
        ///<summary>Test each 32-bit element of a for equality with all other elements in a closer to the least significant bit using writemask k (elements are copied from src when the corresponding mask bit is not set). Each element's comparison forms a zero extended bit vector in dst. (AVX512CD)</summary>
        _MM512_MASK_CONFLICT_EPI32,
        ///<summary>Test each 32-bit element of a for equality with all other elements in a closer to the least significant bit using zeromask k (elements are zeroed out when the corresponding mask bit is not set). Each element's comparison forms a zero extended bit vector in dst. (AVX512CD)</summary>
        _MM512_MASKZ_CONFLICT_EPI32,
        ///<summary>Test each 64-bit element of a for equality with all other elements in a closer to the least significant bit. Each element's comparison forms a zero extended bit vector in dst. (AVX512VL, AVX512CD)</summary>
        _MM_CONFLICT_EPI64,
        ///<summary>Test each 64-bit element of a for equality with all other elements in a closer to the least significant bit using writemask k (elements are copied from src when the corresponding mask bit is not set). Each element's comparison forms a zero extended bit vector in dst. (AVX512VL, AVX512CD)</summary>
        _MM_MASK_CONFLICT_EPI64,
        ///<summary>Test each 64-bit element of a for equality with all other elements in a closer to the least significant bit using zeromask k (elements are zeroed out when the corresponding mask bit is not set). Each element's comparison forms a zero extended bit vector in dst. (AVX512VL, AVX512CD)</summary>
        _MM_MASKZ_CONFLICT_EPI64,
        ///<summary>Test each 64-bit element of a for equality with all other elements in a closer to the least significant bit. Each element's comparison forms a zero extended bit vector in dst. (AVX512VL, AVX512CD)</summary>
        _MM256_CONFLICT_EPI64,
        ///<summary>Test each 64-bit element of a for equality with all other elements in a closer to the least significant bit using writemask k (elements are copied from src when the corresponding mask bit is not set). Each element's comparison forms a zero extended bit vector in dst. (AVX512VL, AVX512CD)</summary>
        _MM256_MASK_CONFLICT_EPI64,
        ///<summary>Test each 64-bit element of a for equality with all other elements in a closer to the least significant bit using zeromask k (elements are zeroed out when the corresponding mask bit is not set). Each element's comparison forms a zero extended bit vector in dst. (AVX512VL, AVX512CD)</summary>
        _MM256_MASKZ_CONFLICT_EPI64,
        ///<summary>Test each 64-bit element of a for equality with all other elements in a closer to the least significant bit. Each element's comparison forms a zero extended bit vector in dst. (AVX512CD)</summary>
        _MM512_CONFLICT_EPI64,
        ///<summary>Test each 64-bit element of a for equality with all other elements in a closer to the least significant bit using writemask k (elements are copied from src when the corresponding mask bit is not set). Each element's comparison forms a zero extended bit vector in dst. (AVX512CD)</summary>
        _MM512_MASK_CONFLICT_EPI64,
        ///<summary>Test each 64-bit element of a for equality with all other elements in a closer to the least significant bit using zeromask k (elements are zeroed out when the corresponding mask bit is not set). Each element's comparison forms a zero extended bit vector in dst. (AVX512CD)</summary>
        _MM512_MASKZ_CONFLICT_EPI64,
        ///<summary>Compute the cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_COS_PD,
        ///<summary>Compute the cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_COS_PD,
        ///<summary>Compute the cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX512F)</summary>
        _MM512_COS_PD,
        ///<summary>Compute the cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_COS_PD,
        ///<summary>Compute the cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_COS_PS,
        ///<summary>Compute the cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_COS_PS,
        ///<summary>Compute the cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX512F)</summary>
        _MM512_COS_PS,
        ///<summary>Compute the cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_COS_PS,
        ///<summary>Compute the cosine of packed double-precision (64-bit) floating-point elements in a expressed in degrees, and store the results in dst. (SSE)</summary>
        _MM_COSD_PD,
        ///<summary>Compute the cosine of packed double-precision (64-bit) floating-point elements in a expressed in degrees, and store the results in dst. (AVX)</summary>
        _MM256_COSD_PD,
        ///<summary>Compute the cosine of packed double-precision (64-bit) floating-point elements in a expressed in degrees, and store the results in dst. (AVX512F)</summary>
        _MM512_COSD_PD,
        ///<summary>Compute the cosine of packed double-precision (64-bit) floating-point elements in a expressed in degrees, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_COSD_PD,
        ///<summary>Compute the cosine of packed single-precision (32-bit) floating-point elements in a expressed in degrees, and store the results in dst. (SSE)</summary>
        _MM_COSD_PS,
        ///<summary>Compute the cosine of packed single-precision (32-bit) floating-point elements in a expressed in degrees, and store the results in dst. (AVX)</summary>
        _MM256_COSD_PS,
        ///<summary>Compute the cosine of packed single-precision (32-bit) floating-point elements in a expressed in degrees, and store the results in dst. (AVX512F)</summary>
        _MM512_COSD_PS,
        ///<summary>Compute the cosine of packed single-precision (32-bit) floating-point elements in a expressed in degrees, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_COSD_PS,
        ///<summary>Compute the hyperbolic cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_COSH_PD,
        ///<summary>Compute the hyperbolic cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_COSH_PD,
        ///<summary>Compute the hyperbolic cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX512F)</summary>
        _MM512_COSH_PD,
        ///<summary>Compute the hyperbolic cosine of packed double-precision (64-bit) floating-point elements in a expressed in radians, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_COSH_PD,
        ///<summary>Compute the hyperbolic cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (SSE)</summary>
        _MM_COSH_PS,
        ///<summary>Compute the hyperbolic cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX)</summary>
        _MM256_COSH_PS,
        ///<summary>Compute the hyperbolic cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst. (AVX512F)</summary>
        _MM512_COSH_PS,
        ///<summary>Compute the hyperbolic cosine of packed single-precision (32-bit) floating-point elements in a expressed in radians, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_COSH_PS,
        ///<summary>Counts the number of set bits in 32-bit unsigned integer r1, returning the results in dst. (KNCNI)</summary>
        _MM_COUNTBITS_32,
        ///<summary>Counts the number of set bits in double-precision (32-bit) unsigned integer r1, returning the results in dst. (KNCNI)</summary>
        _MM_COUNTBITS_64,
        ///<summary>Starting with the initial value in crc, accumulates a CRC32 value for unsigned 16-bit integer v, and stores the result in dst. (SSE4.2)</summary>
        _MM_CRC32_U16,
        ///<summary>Starting with the initial value in crc, accumulates a CRC32 value for unsigned 32-bit integer v, and stores the result in dst. (SSE4.2)</summary>
        _MM_CRC32_U32,
        ///<summary>Starting with the initial value in crc, accumulates a CRC32 value for unsigned 64-bit integer v, and stores the result in dst. (SSE4.2)</summary>
        _MM_CRC32_U64,
        ///<summary>Starting with the initial value in crc, accumulates a CRC32 value for unsigned 8-bit integer v, and stores the result in dst. (SSE4.2)</summary>
        _MM_CRC32_U8,
        ///<summary>Compute the square root of packed complex single-precision (32-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_CSQRT_PS,
        ///<summary>Compute the square root of packed complex single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_CSQRT_PS,
        ///<summary>Convert packed 32-bit integers in b to packed single-precision (32-bit) floating-point elements, store the results in the lower 2 elements of dst, and copy the upper 2 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CVT_PI2PS,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst. (SSE)</summary>
        _MM_CVT_PS2PI,
        ///<summary>Convert packed 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_CVT_ROUNDEPI32_PS,
        ///<summary>Convert packed 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_CVT_ROUNDEPI32_PS,
        ///<summary>Convert packed 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_CVT_ROUNDEPI32_PS,
        ///<summary>Convert packed 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_CVT_ROUNDEPI64_PD,
        ///<summary>Convert packed 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASK_CVT_ROUNDEPI64_PD,
        ///<summary>Convert packed 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASKZ_CVT_ROUNDEPI64_PD,
        ///<summary>Convert packed 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_CVT_ROUNDEPI64_PS,
        ///<summary>Convert packed 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASK_CVT_ROUNDEPI64_PS,
        ///<summary>Convert packed 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASKZ_CVT_ROUNDEPI64_PS,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_CVT_ROUNDEPU32_PS,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_CVT_ROUNDEPU32_PS,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_CVT_ROUNDEPU32_PS,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_CVT_ROUNDEPU64_PD,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASK_CVT_ROUNDEPU64_PD,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASKZ_CVT_ROUNDEPU64_PD,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_CVT_ROUNDEPU64_PS,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASK_CVT_ROUNDEPU64_PS,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASKZ_CVT_ROUNDEPU64_PS,
        ///<summary>Convert the 32-bit integer b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDI32_SS,
        ///<summary>Convert the 64-bit integer b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDI64_SD,
        ///<summary>Convert the 64-bit integer b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDI64_SS,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_CVT_ROUNDPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_CVT_ROUNDPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_CVT_ROUNDPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_CVT_ROUNDPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASK_CVT_ROUNDPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASKZ_CVT_ROUNDPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_CVT_ROUNDPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_CVT_ROUNDPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_CVT_ROUNDPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_CVT_ROUNDPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASK_CVT_ROUNDPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASKZ_CVT_ROUNDPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_CVT_ROUNDPD_PS,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_CVT_ROUNDPD_PS,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_CVT_ROUNDPD_PS,
        ///<summary>Performs element-by-element conversion of packed double-precision (64-bit) floating-point elements in v2 to packed single-precision (32-bit) floating-point elements, storing the results in dst. Results are written to the lower half of dst, and the upper half locations are set to '0'. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_CVT_ROUNDPD_PSLO,
        ///<summary>Performs element-by-element conversion of packed double-precision (64-bit) floating-point elements in v2 to packed single-precision (32-bit) floating-point elements, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). Results are written to the lower half of dst, and the upper half locations are set to '0'. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_MASK_CVT_ROUNDPD_PSLO,
        ///<summary>Convert packed half-precision (16-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst.  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_CVT_ROUNDPH_PS,
        ///<summary>Convert packed half-precision (16-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_MASK_CVT_ROUNDPH_PS,
        ///<summary>Convert packed half-precision (16-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_MASKZ_CVT_ROUNDPH_PS,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_CVT_ROUNDPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_CVT_ROUNDPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_CVT_ROUNDPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_CVT_ROUNDPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	 Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASK_CVT_ROUNDPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASKZ_CVT_ROUNDPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_CVT_ROUNDPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_CVT_ROUNDPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_CVT_ROUNDPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_CVT_ROUNDPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASK_CVT_ROUNDPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512DQ)</summary>
        _MM512_MASKZ_CVT_ROUNDPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. 	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_CVT_ROUNDPS_PD,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_MASK_CVT_ROUNDPS_PD,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_MASKZ_CVT_ROUNDPS_PD,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVT_ROUNDPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVT_ROUNDPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVT_ROUNDPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVT_ROUNDPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_CVT_ROUNDPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_CVT_ROUNDPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_CVT_ROUNDPS_PH,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 32-bit integer, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSD_I32,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 64-bit integer, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSD_I64,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 32-bit integer, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSD_SI32,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 64-bit integer, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSD_SI64,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSD_SS,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_CVT_ROUNDSD_SS,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_CVT_ROUNDSD_SS,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to an unsigned 32-bit integer, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSD_U32,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to an unsigned 64-bit integer, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSD_U64,
        ///<summary>Convert the 32-bit integer b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSI32_SS,
        ///<summary>Convert the 64-bit integer b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSI64_SD,
        ///<summary>Convert the 64-bit integer b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSI64_SS,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 32-bit integer, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSS_I32,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 64-bit integer, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSS_I64,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSS_SD,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_CVT_ROUNDSS_SD,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_CVT_ROUNDSS_SD,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 32-bit integer, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSS_SI32,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 64-bit integer, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSS_SI64,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to an unsigned 32-bit integer, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSS_U32,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to an unsigned 64-bit integer, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDSS_U64,
        ///<summary>Convert the unsigned 32-bit integer b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDU32_SS,
        ///<summary>Convert the unsigned 64-bit integer b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDU64_SD,
        ///<summary>Convert the unsigned 64-bit integer b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVT_ROUNDU64_SS,
        ///<summary>Convert the 32-bit integer b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CVT_SI2SS,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 32-bit integer, and store the result in dst. (SSE)</summary>
        _MM_CVT_SS2SI,
        ///<summary>Sign extend packed 16-bit integers in a to packed 32-bit integers, and store the results in dst. (SSE4.1)</summary>
        _MM_CVTEPI16_EPI32,
        ///<summary>Sign extend packed 16-bit integers in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI16_EPI32,
        ///<summary>Sign extend packed 16-bit integers in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPI16_EPI32,
        ///<summary>Sign extend packed 16-bit integers in a to packed 32-bit integers, and store the results in dst. (AVX2)</summary>
        _MM256_CVTEPI16_EPI32,
        ///<summary>Sign extend packed 16-bit integers in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI16_EPI32,
        ///<summary>Sign extend packed 16-bit integers in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPI16_EPI32,
        ///<summary>Sign extend packed 16-bit integers in a to packed 32-bit integers, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPI16_EPI32,
        ///<summary>Sign extend packed 16-bit integers in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPI16_EPI32,
        ///<summary>Sign extend packed 16-bit integers in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPI16_EPI32,
        ///<summary>Sign extend packed 16-bit integers in a to packed 64-bit integers, and store the results in dst. (SSE4.1)</summary>
        _MM_CVTEPI16_EPI64,
        ///<summary>Sign extend packed 16-bit integers in the low 4 bytes of a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI16_EPI64,
        ///<summary>Sign extend packed 16-bit integers in the low 4 bytes of a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPI16_EPI64,
        ///<summary>Sign extend packed 16-bit integers in a to packed 64-bit integers, and store the results in dst. (AVX2)</summary>
        _MM256_CVTEPI16_EPI64,
        ///<summary>Sign extend packed 16-bit integers in the low 8 bytes of a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI16_EPI64,
        ///<summary>Sign extend packed 16-bit integers in the low 8 bytes of a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPI16_EPI64,
        ///<summary>Sign extend packed 16-bit integers in a to packed 64-bit integers, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPI16_EPI64,
        ///<summary>Sign extend packed 16-bit integers in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPI16_EPI64,
        ///<summary>Sign extend packed 16-bit integers in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPI16_EPI64,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512BW)</summary>
        _MM_CVTEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CVTEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_CVTEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512BW)</summary>
        _MM256_CVTEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CVTEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_CVTEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with truncation, and store the results in dst. (AVX512BW)</summary>
        _MM512_CVTEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CVTEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_CVTEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CVTEPI16_STOREU_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CVTEPI16_STOREU_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512BW)</summary>
        _MM512_MASK_CVTEPI16_STOREU_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with truncation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPI32_EPI16,
        ///<summary>Sign extend packed 32-bit integers in a to packed 64-bit integers, and store the results in dst. (SSE4.1)</summary>
        _MM_CVTEPI32_EPI64,
        ///<summary>Sign extend packed 32-bit integers in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI32_EPI64,
        ///<summary>Sign extend packed 32-bit integers in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPI32_EPI64,
        ///<summary>Sign extend packed 32-bit integers in a to packed 64-bit integers, and store the results in dst. (AVX2)</summary>
        _MM256_CVTEPI32_EPI64,
        ///<summary>Sign extend packed 32-bit integers in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI32_EPI64,
        ///<summary>Sign extend packed 32-bit integers in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPI32_EPI64,
        ///<summary>Sign extend packed 32-bit integers in a to packed 64-bit integers, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPI32_EPI64,
        ///<summary>Sign extend packed 32-bit integers in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPI32_EPI64,
        ///<summary>Sign extend packed 32-bit integers in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPI32_EPI64,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with truncation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (SSE2)</summary>
        _MM_CVTEPI32_PD,
        ///<summary>Convert packed 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI32_PD,
        ///<summary>Convert packed 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPI32_PD,
        ///<summary>Convert packed 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (AVX)</summary>
        _MM256_CVTEPI32_PD,
        ///<summary>Convert packed 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI32_PD,
        ///<summary>Convert packed 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPI32_PD,
        ///<summary>Convert packed 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPI32_PD,
        ///<summary>Convert packed 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPI32_PD,
        ///<summary>Convert packed 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPI32_PD,
        ///<summary>Convert packed 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (SSE2)</summary>
        _MM_CVTEPI32_PS,
        ///<summary>Convert packed 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI32_PS,
        ///<summary>Convert packed 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPI32_PS,
        ///<summary>Convert packed 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (AVX)</summary>
        _MM256_CVTEPI32_PS,
        ///<summary>Convert packed 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI32_PS,
        ///<summary>Convert packed 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPI32_PS,
        ///<summary>Convert packed 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPI32_PS,
        ///<summary>Convert packed 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPI32_PS,
        ///<summary>Convert packed 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPI32_PS,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI32_STOREU_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI32_STOREU_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTEPI32_STOREU_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI32_STOREU_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI32_STOREU_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTEPI32_STOREU_EPI8,
        ///<summary>Performs element-by-element conversion of the lower half of packed 32-bit integer elements in v2 to packed double-precision (64-bit) floating-point elements, storing the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_CVTEPI32LO_PD,
        ///<summary>Performs element-by-element conversion of the lower half of packed 32-bit integer elements in v2 to packed double-precision (64-bit) floating-point elements, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CVTEPI32LO_PD,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with truncation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with truncation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with truncation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM_CVTEPI64_PD,
        ///<summary>Convert packed 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_CVTEPI64_PD,
        ///<summary>Convert packed 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_CVTEPI64_PD,
        ///<summary>Convert packed 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_CVTEPI64_PD,
        ///<summary>Convert packed 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_CVTEPI64_PD,
        ///<summary>Convert packed 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_CVTEPI64_PD,
        ///<summary>Convert packed 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (AVX512DQ)</summary>
        _MM512_CVTEPI64_PD,
        ///<summary>Convert packed 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_CVTEPI64_PD,
        ///<summary>Convert packed 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_CVTEPI64_PD,
        ///<summary>Convert packed 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM_CVTEPI64_PS,
        ///<summary>Convert packed 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_CVTEPI64_PS,
        ///<summary>Convert packed 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_CVTEPI64_PS,
        ///<summary>Convert packed 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_CVTEPI64_PS,
        ///<summary>Convert packed 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_CVTEPI64_PS,
        ///<summary>Convert packed 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_CVTEPI64_PS,
        ///<summary>Convert packed 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (AVX512DQ)</summary>
        _MM512_CVTEPI64_PS,
        ///<summary>Convert packed 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_CVTEPI64_PS,
        ///<summary>Convert packed 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_CVTEPI64_PS,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI64_STOREU_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI64_STOREU_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTEPI64_STOREU_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI64_STOREU_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI64_STOREU_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTEPI64_STOREU_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI64_STOREU_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI64_STOREU_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with truncation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTEPI64_STOREU_EPI8,
        ///<summary>Sign extend packed 8-bit integers in a to packed 16-bit integers, and store the results in dst. (SSE4.1)</summary>
        _MM_CVTEPI8_EPI16,
        ///<summary>Sign extend packed 8-bit integers in a to packed 16-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CVTEPI8_EPI16,
        ///<summary>Sign extend packed 8-bit integers in a to packed 16-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_CVTEPI8_EPI16,
        ///<summary>Sign extend packed 8-bit integers in a to packed 16-bit integers, and store the results in dst. (AVX2)</summary>
        _MM256_CVTEPI8_EPI16,
        ///<summary>Sign extend packed 8-bit integers in a to packed 16-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CVTEPI8_EPI16,
        ///<summary>Sign extend packed 8-bit integers in a to packed 16-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_CVTEPI8_EPI16,
        ///<summary>Sign extend packed 8-bit integers in a to packed 16-bit integers, and store the results in dst. (AVX512BW)</summary>
        _MM512_CVTEPI8_EPI16,
        ///<summary>Sign extend packed 8-bit integers in a to packed 16-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CVTEPI8_EPI16,
        ///<summary>Sign extend packed 8-bit integers in a to packed 16-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_CVTEPI8_EPI16,
        ///<summary>Sign extend packed 8-bit integers in a to packed 32-bit integers, and store the results in dst. (SSE4.1)</summary>
        _MM_CVTEPI8_EPI32,
        ///<summary>Sign extend packed 8-bit integers in the low 4 bytes of a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI8_EPI32,
        ///<summary>Sign extend packed 8-bit integers in the low 4 bytes of a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPI8_EPI32,
        ///<summary>Sign extend packed 8-bit integers in a to packed 32-bit integers, and store the results in dst. (AVX2)</summary>
        _MM256_CVTEPI8_EPI32,
        ///<summary>Sign extend packed 8-bit integers in the low 8 bytes of a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI8_EPI32,
        ///<summary>Sign extend packed 8-bit integers in the low 8 bytes of a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPI8_EPI32,
        ///<summary>Sign extend packed 8-bit integers in a to packed 32-bit integers, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPI8_EPI32,
        ///<summary>Sign extend packed 8-bit integers in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPI8_EPI32,
        ///<summary>Sign extend packed 8-bit integers in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPI8_EPI32,
        ///<summary>Sign extend packed 8-bit integers in the low 8 bytes of a to packed 64-bit integers, and store the results in dst. (SSE4.1)</summary>
        _MM_CVTEPI8_EPI64,
        ///<summary>Sign extend packed 8-bit integers in the low 2 bytes of a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPI8_EPI64,
        ///<summary>Sign extend packed 8-bit integers in the low 2 bytes of a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPI8_EPI64,
        ///<summary>Sign extend packed 8-bit integers in the low 8 bytes of a to packed 64-bit integers, and store the results in dst. (AVX2)</summary>
        _MM256_CVTEPI8_EPI64,
        ///<summary>Sign extend packed 8-bit integers in the low 4 bytes of a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPI8_EPI64,
        ///<summary>Sign extend packed 8-bit integers in the low 4 bytes of a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPI8_EPI64,
        ///<summary>Sign extend packed 8-bit integers in the low 8 bytes of a to packed 64-bit integers, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPI8_EPI64,
        ///<summary>Sign extend packed 8-bit integers in the low 8 bytes of a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPI8_EPI64,
        ///<summary>Sign extend packed 8-bit integers in the low 8 bytes of a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPI8_EPI64,
        ///<summary>Zero extend packed unsigned 16-bit integers in a to packed 32-bit integers, and store the results in dst. (SSE4.1)</summary>
        _MM_CVTEPU16_EPI32,
        ///<summary>Zero extend packed unsigned 16-bit integers in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPU16_EPI32,
        ///<summary>Zero extend packed unsigned 16-bit integers in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPU16_EPI32,
        ///<summary>Zero extend packed unsigned 16-bit integers in a to packed 32-bit integers, and store the results in dst. (AVX2)</summary>
        _MM256_CVTEPU16_EPI32,
        ///<summary>Zero extend packed unsigned 16-bit integers in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPU16_EPI32,
        ///<summary>Zero extend packed unsigned 16-bit integers in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPU16_EPI32,
        ///<summary>Zero extend packed unsigned 16-bit integers in a to packed 32-bit integers, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPU16_EPI32,
        ///<summary>Zero extend packed unsigned 16-bit integers in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPU16_EPI32,
        ///<summary>Zero extend packed unsigned 16-bit integers in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPU16_EPI32,
        ///<summary>Zero extend packed unsigned 16-bit integers in a to packed 64-bit integers, and store the results in dst. (SSE4.1)</summary>
        _MM_CVTEPU16_EPI64,
        ///<summary>Zero extend packed unsigned 16-bit integers in the low 4 bytes of a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPU16_EPI64,
        ///<summary>Zero extend packed unsigned 16-bit integers in the low 4 bytes of a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPU16_EPI64,
        ///<summary>Zero extend packed unsigned 16-bit integers in a to packed 64-bit integers, and store the results in dst. (AVX2)</summary>
        _MM256_CVTEPU16_EPI64,
        ///<summary>Zero extend packed unsigned 16-bit integers in the low 8 bytes of a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPU16_EPI64,
        ///<summary>Zero extend packed unsigned 16-bit integers in the low 8 bytes of a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPU16_EPI64,
        ///<summary>Zero extend packed unsigned 16-bit integers in a to packed 64-bit integers, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPU16_EPI64,
        ///<summary>Zero extend packed unsigned 16-bit integers in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPU16_EPI64,
        ///<summary>Zero extend packed unsigned 16-bit integers in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPU16_EPI64,
        ///<summary>Zero extend packed unsigned 32-bit integers in a to packed 64-bit integers, and store the results in dst. (SSE4.1)</summary>
        _MM_CVTEPU32_EPI64,
        ///<summary>Zero extend packed unsigned 32-bit integers in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPU32_EPI64,
        ///<summary>Zero extend packed unsigned 32-bit integers in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPU32_EPI64,
        ///<summary>Zero extend packed unsigned 32-bit integers in a to packed 64-bit integers, and store the results in dst. (AVX2)</summary>
        _MM256_CVTEPU32_EPI64,
        ///<summary>Zero extend packed unsigned 32-bit integers in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPU32_EPI64,
        ///<summary>Zero extend packed unsigned 32-bit integers in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPU32_EPI64,
        ///<summary>Zero extend packed unsigned 32-bit integers in a to packed 64-bit integers, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPU32_EPI64,
        ///<summary>Zero extend packed unsigned 32-bit integers in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPU32_EPI64,
        ///<summary>Zero extend packed unsigned 32-bit integers in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPU32_EPI64,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTEPU32_PD,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPU32_PD,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPU32_PD,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTEPU32_PD,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPU32_PD,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPU32_PD,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPU32_PD,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPU32_PD,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPU32_PD,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPU32_PS,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPU32_PS,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPU32_PS,
        ///<summary>Performs element-by-element conversion of the lower half of packed 32-bit unsigned integer elements in v2 to packed double-precision (64-bit) floating-point elements, storing the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_CVTEPU32LO_PD,
        ///<summary>Performs element-by-element conversion of the lower half of 32-bit unsigned integer elements in v2 to packed double-precision (64-bit) floating-point elements, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CVTEPU32LO_PD,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM_CVTEPU64_PD,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_CVTEPU64_PD,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_CVTEPU64_PD,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_CVTEPU64_PD,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_CVTEPU64_PD,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_CVTEPU64_PD,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (AVX512DQ)</summary>
        _MM512_CVTEPU64_PD,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_CVTEPU64_PD,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_CVTEPU64_PD,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM_CVTEPU64_PS,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_CVTEPU64_PS,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_CVTEPU64_PS,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_CVTEPU64_PS,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_CVTEPU64_PS,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_CVTEPU64_PS,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (AVX512DQ)</summary>
        _MM512_CVTEPU64_PS,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_CVTEPU64_PS,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_CVTEPU64_PS,
        ///<summary>Zero extend packed unsigned 8-bit integers in a to packed 16-bit integers, and store the results in dst. (SSE4.1)</summary>
        _MM_CVTEPU8_EPI16,
        ///<summary>Zero extend packed unsigned 8-bit integers in a to packed 16-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CVTEPU8_EPI16,
        ///<summary>Zero extend packed unsigned 8-bit integers in a to packed 16-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_CVTEPU8_EPI16,
        ///<summary>Zero extend packed unsigned 8-bit integers in a to packed 16-bit integers, and store the results in dst. (AVX2)</summary>
        _MM256_CVTEPU8_EPI16,
        ///<summary>Zero extend packed unsigned 8-bit integers in a to packed 16-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CVTEPU8_EPI16,
        ///<summary>Zero extend packed unsigned 8-bit integers in a to packed 16-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_CVTEPU8_EPI16,
        ///<summary>Zero extend packed unsigned 8-bit integers in a to packed 16-bit integers, and store the results in dst. (AVX512BW)</summary>
        _MM512_CVTEPU8_EPI16,
        ///<summary>Zero extend packed unsigned 8-bit integers in a to packed 16-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CVTEPU8_EPI16,
        ///<summary>Zero extend packed unsigned 8-bit integers in a to packed 16-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_CVTEPU8_EPI16,
        ///<summary>Zero extend packed unsigned 8-bit integers in a to packed 32-bit integers, and store the results in dst. (SSE4.1)</summary>
        _MM_CVTEPU8_EPI32,
        ///<summary>Zero extend packed unsigned 8-bit integers in the low 4 bytes of a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPU8_EPI32,
        ///<summary>Zero extend packed unsigned 8-bit integers in th elow 4 bytes of a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPU8_EPI32,
        ///<summary>Zero extend packed unsigned 8-bit integers in a to packed 32-bit integers, and store the results in dst. (AVX2)</summary>
        _MM256_CVTEPU8_EPI32,
        ///<summary>Zero extend packed unsigned 8-bit integers in the low 8 bytes of a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPU8_EPI32,
        ///<summary>Zero extend packed unsigned 8-bit integers in the low 8 bytes of a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPU8_EPI32,
        ///<summary>Zero extend packed unsigned 8-bit integers in a to packed 32-bit integers, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPU8_EPI32,
        ///<summary>Zero extend packed unsigned 8-bit integers in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPU8_EPI32,
        ///<summary>Zero extend packed unsigned 8-bit integers in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPU8_EPI32,
        ///<summary>Zero extend packed unsigned 8-bit integers in the low 8 byte sof a to packed 64-bit integers, and store the results in dst. (SSE4.1)</summary>
        _MM_CVTEPU8_EPI64,
        ///<summary>Zero extend packed unsigned 8-bit integers in the low 2 bytes of a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTEPU8_EPI64,
        ///<summary>Zero extend packed unsigned 8-bit integers in the low 2 bytes of a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTEPU8_EPI64,
        ///<summary>Zero extend packed unsigned 8-bit integers in the low 8 byte sof a to packed 64-bit integers, and store the results in dst. (AVX2)</summary>
        _MM256_CVTEPU8_EPI64,
        ///<summary>Zero extend packed unsigned 8-bit integers in the low 4 bytes of a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTEPU8_EPI64,
        ///<summary>Zero extend packed unsigned 8-bit integers in the low 4 bytes of a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTEPU8_EPI64,
        ///<summary>Zero extend packed unsigned 8-bit integers in the low 8 byte sof a to packed 64-bit integers, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTEPU8_EPI64,
        ///<summary>Zero extend packed unsigned 8-bit integers in the low 8 bytes of a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTEPU8_EPI64,
        ///<summary>Zero extend packed unsigned 8-bit integers in the low 8 bytes of a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTEPU8_EPI64,
        ///<summary>Performs element-by-element conversion of packed 32-bit integer elements in v2 to packed single-precision (32-bit) floating-point elements and performing an optional exponent adjust using expadj, storing the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_CVTFXPNT_ROUND_ADJUSTEPI32_PS,
        ///<summary>Performs element-by-element conversion of packed 32-bit unsigned integer elements in v2 to packed single-precision (32-bit) floating-point elements and performing an optional exponent adjust using expadj, storing the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_CVTFXPNT_ROUND_ADJUSTEPU32_PS,
        ///<summary>Performs element-by-element conversion of packed 32-bit unsigned integer elements in v2 to packed single-precision (32-bit) floating-point elements and performing an optional exponent adjust using expadj, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_MASK_CVTFXPNT_ROUND_ADJUSTEPU32_PS,
        ///<summary>Performs element-by-element conversion of packed single-precision (32-bit) floating-point elements in v2 to packed 32-bit integer elements and performs an optional exponent adjust using expadj, storing the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_CVTFXPNT_ROUND_ADJUSTPS_EPI32,
        ///<summary>Performs element-by-element conversion of packed single-precision (32-bit) floating-point elements in v2 to packed 32-bit unsigned integer elements and performing an optional exponent adjust using expadj, storing the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_CVTFXPNT_ROUND_ADJUSTPS_EPU32,
        ///<summary>Performs an element-by-element conversion of elements in packed double-precision (64-bit) floating-point vector v2 to 32-bit integer elements, storing them in the lower half of dst. The elements in the upper half of dst are set to 0. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_CVTFXPNT_ROUNDPD_EPI32LO,
        ///<summary>Performs an element-by-element conversion of elements in packed double-precision (64-bit) floating-point vector v2 to 32-bit integer elements, storing them in the lower half of dst using writemask k (elements are copied from src when the corresponding mask bit is not set). The elements in the upper half of dst are set to 0. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_MASK_CVTFXPNT_ROUNDPD_EPI32LO,
        ///<summary>Performs element-by-element conversion of packed double-precision (64-bit) floating-point elements in v2 to packed 32-bit unsigned integer elements, storing the results in dst. Results are written to the lower half of dst, and the upper half locations are set to '0'. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_CVTFXPNT_ROUNDPD_EPU32LO,
        ///<summary>Performs element-by-element conversion of packed double-precision (64-bit) floating-point elements in v2 to packed 32-bit unsigned integer elements, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). Results are written to the lower half of dst, and the upper half locations are set to '0'. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_MASK_CVTFXPNT_ROUNDPD_EPU32LO,
        ///<summary>Convert the 32-bit integer b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_CVTI32_SD,
        ///<summary>Convert the 32-bit integer b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_CVTI32_SS,
        ///<summary>Convert the 64-bit integer b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_CVTI64_SD,
        ///<summary>Convert the 64-bit integer b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_CVTI64_SS,
        ///<summary>Copy 64-bit integer a to dst. (MMX)</summary>
        _MM_CVTM64_SI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst. (SSE2)</summary>
        _MM_CVTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst. (AVX)</summary>
        _MM256_CVTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM_CVTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_CVTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_CVTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_CVTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_CVTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_CVTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst. (AVX512DQ)</summary>
        _MM512_CVTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_CVTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_CVTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM_CVTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_CVTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_CVTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_CVTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_CVTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_CVTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst. (AVX512DQ)</summary>
        _MM512_CVTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_CVTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_CVTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst. (SSE2)</summary>
        _MM_CVTPD_PI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (SSE2)</summary>
        _MM_CVTPD_PS,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTPD_PS,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTPD_PS,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (AVX)</summary>
        _MM256_CVTPD_PS,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTPD_PS,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTPD_PS,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTPD_PS,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTPD_PS,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTPD_PS,
        ///<summary>Performs an element-by-element conversion of packed double-precision (64-bit) floating-point elements in v2 to single-precision (32-bit) floating-point elements and stores them in dst. The elements are stored in the lower half of the results vector, while the remaining upper half locations are set to 0. (AVX512F, KNCNI)</summary>
        _MM512_CVTPD_PSLO,
        ///<summary>Performs an element-by-element conversion of packed double-precision (64-bit) floating-point elements in v2 to single-precision (32-bit) floating-point elements and stores them in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). The elements are stored in the lower half of the results vector, while the remaining upper half locations are set to 0. (AVX512F, KNCNI)</summary>
        _MM512_MASK_CVTPD_PSLO,
        ///<summary>Convert packed half-precision (16-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (FP16C)</summary>
        _MM_CVTPH_PS,
        ///<summary>Convert packed half-precision (16-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTPH_PS,
        ///<summary>Convert packed half-precision (16-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTPH_PS,
        ///<summary>Convert packed half-precision (16-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (FP16C)</summary>
        _MM256_CVTPH_PS,
        ///<summary>Convert packed half-precision (16-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTPH_PS,
        ///<summary>Convert packed half-precision (16-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTPH_PS,
        ///<summary>Convert packed half-precision (16-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTPH_PS,
        ///<summary>Convert packed half-precision (16-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTPH_PS,
        ///<summary>Convert packed half-precision (16-bit) floating-point elements in a to packed single-precision (32-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTPH_PS,
        ///<summary>Convert packed 16-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (SSE)</summary>
        _MM_CVTPI16_PS,
        ///<summary>Convert packed 32-bit integers in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (SSE2)</summary>
        _MM_CVTPI32_PD,
        ///<summary>Convert packed 32-bit integers in b to packed single-precision (32-bit) floating-point elements, store the results in the lower 2 elements of dst, and copy the upper 2 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CVTPI32_PS,
        ///<summary>Convert packed 32-bit integers in a to packed single-precision (32-bit) floating-point elements, store the results in the lower 2 elements of dst, then covert the packed 32-bit integers in a to single-precision (32-bit) floating-point element, and store the results in the upper 2 elements of dst. (SSE)</summary>
        _MM_CVTPI32X2_PS,
        ///<summary>Convert the lower packed 8-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (SSE)</summary>
        _MM_CVTPI8_PS,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst. (SSE2)</summary>
        _MM_CVTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst. (AVX)</summary>
        _MM256_CVTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM_CVTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_CVTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_CVTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_CVTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_CVTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_CVTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst. (AVX512DQ)</summary>
        _MM512_CVTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_CVTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_CVTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM_CVTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_CVTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_CVTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_CVTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_CVTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_CVTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst. (AVX512DQ)</summary>
        _MM512_CVTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_CVTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_CVTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (SSE2)</summary>
        _MM_CVTPS_PD,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (AVX)</summary>
        _MM256_CVTPS_PD,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed double-precision (64-bit) floating-point elements, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTPS_PD,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTPS_PD,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed double-precision (64-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTPS_PD,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (FP16C)</summary>
        _MM_CVTPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (FP16C)</summary>
        _MM256_CVTPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_CVTPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_CVTPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed half-precision (16-bit) floating-point elements, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_CVTPS_PH,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 16-bit integers, and store the results in dst. (SSE)</summary>
        _MM_CVTPS_PI16,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst. (SSE)</summary>
        _MM_CVTPS_PI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 8-bit integers, and store the results in lower 4 elements of dst. (SSE)</summary>
        _MM_CVTPS_PI8,
        ///<summary>Performs element-by-element conversion of the lower half of packed single-precision (32-bit) floating-point elements in v2 to packed double-precision (64-bit) floating-point elements, storing the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_CVTPSLO_PD,
        ///<summary>Performs element-by-element conversion of the lower half of packed single-precision (32-bit) floating-point elements in v2 to packed double-precision (64-bit) floating-point elements, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_CVTPSLO_PD,
        ///<summary>Convert packed unsigned 16-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (SSE)</summary>
        _MM_CVTPU16_PS,
        ///<summary>Convert the lower packed unsigned 8-bit integers in a to packed single-precision (32-bit) floating-point elements, and store the results in dst. (SSE)</summary>
        _MM_CVTPU8_PS,
        ///<summary>Copy the lower double-precision (64-bit) floating-point element of a to dst. (SSE2)</summary>
        _MM_CVTSD_F64,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 32-bit integer, and store the result in dst. (AVX512F)</summary>
        _MM_CVTSD_I32,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 64-bit integer, and store the result in dst. (AVX512F)</summary>
        _MM_CVTSD_I64,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 32-bit integer, and store the result in dst. (SSE2)</summary>
        _MM_CVTSD_SI32,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 64-bit integer, and store the result in dst. (SSE2)</summary>
        _MM_CVTSD_SI64,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 64-bit integer, and store the result in dst. (SSE2)</summary>
        _MM_CVTSD_SI64X,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CVTSD_SS,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASK_CVTSD_SS,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASKZ_CVTSD_SS,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to an unsigned 32-bit integer, and store the result in dst. (AVX512F)</summary>
        _MM_CVTSD_U32,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to an unsigned 64-bit integer, and store the result in dst. (AVX512F)</summary>
        _MM_CVTSD_U64,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst. (AVX512VL, AVX512BW)</summary>
        _MM_CVTSEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CVTSEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_CVTSEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst. (AVX512VL, AVX512BW)</summary>
        _MM256_CVTSEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CVTSEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_CVTSEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst. (AVX512BW)</summary>
        _MM512_CVTSEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CVTSEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_CVTSEPI16_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CVTSEPI16_STOREU_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CVTSEPI16_STOREU_EPI8,
        ///<summary>Convert packed 16-bit integers in a to packed 8-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512BW)</summary>
        _MM512_MASK_CVTSEPI16_STOREU_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTSEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTSEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTSEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTSEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTSEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTSEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTSEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTSEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTSEPI32_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTSEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTSEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTSEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTSEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTSEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTSEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTSEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTSEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTSEPI32_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTSEPI32_STOREU_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTSEPI32_STOREU_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 16-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTSEPI32_STOREU_EPI16,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTSEPI32_STOREU_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTSEPI32_STOREU_EPI8,
        ///<summary>Convert packed 32-bit integers in a to packed 8-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTSEPI32_STOREU_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTSEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTSEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTSEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTSEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTSEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTSEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTSEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTSEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTSEPI64_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with signed saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTSEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTSEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTSEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with signed saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTSEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTSEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTSEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with signed saturation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTSEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTSEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTSEPI64_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTSEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTSEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTSEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTSEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTSEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTSEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTSEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTSEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with signed saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTSEPI64_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTSEPI64_STOREU_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTSEPI64_STOREU_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 16-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTSEPI64_STOREU_EPI16,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTSEPI64_STOREU_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTSEPI64_STOREU_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 32-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTSEPI64_STOREU_EPI32,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTSEPI64_STOREU_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTSEPI64_STOREU_EPI8,
        ///<summary>Convert packed 64-bit integers in a to packed 8-bit integers with signed saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTSEPI64_STOREU_EPI8,
        ///<summary>Convert the half-precision (16-bit) floating-point value a to a single-precision (32-bit) floating-point value, and store the result in dst. ()</summary>
        _CVTSH_SS,
        ///<summary>Copy the lower 32-bit integer in a to dst. (SSE2)</summary>
        _MM_CVTSI128_SI32,
        ///<summary>Copy the lower 64-bit integer in a to dst. (SSE2)</summary>
        _MM_CVTSI128_SI64,
        ///<summary>Copy the lower 64-bit integer in a to dst. (SSE2)</summary>
        _MM_CVTSI128_SI64X,
        ///<summary>Convert the 32-bit integer b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CVTSI32_SD,
        ///<summary>Copy 32-bit integer a to the lower elements of dst, and zero the upper elements of dst. (SSE2)</summary>
        _MM_CVTSI32_SI128,
        ///<summary>Copy 32-bit integer a to the lower elements of dst, and zero the upper element of dst. (MMX)</summary>
        _MM_CVTSI32_SI64,
        ///<summary>Convert the 32-bit integer b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CVTSI32_SS,
        ///<summary>Copy 64-bit integer a to dst. (MMX)</summary>
        _MM_CVTSI64_M64,
        ///<summary>Convert the 64-bit integer b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CVTSI64_SD,
        ///<summary>Copy 64-bit integer a to the lower element of dst, and zero the upper element. (SSE2)</summary>
        _MM_CVTSI64_SI128,
        ///<summary>Copy the lower 32-bit integer in a to dst. (MMX)</summary>
        _MM_CVTSI64_SI32,
        ///<summary>Convert the 64-bit integer b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_CVTSI64_SS,
        ///<summary>Convert the 64-bit integer b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CVTSI64X_SD,
        ///<summary>Copy 64-bit integer a to the lower element of dst, and zero the upper element. (SSE2)</summary>
        _MM_CVTSI64X_SI128,
        ///<summary>Copy the lower single-precision (32-bit) floating-point element of a to dst. (SSE)</summary>
        _MM_CVTSS_F32,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 32-bit integer, and store the result in dst. (AVX512F)</summary>
        _MM_CVTSS_I32,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 64-bit integer, and store the result in dst. (AVX512F)</summary>
        _MM_CVTSS_I64,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_CVTSS_SD,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASK_CVTSS_SD,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASKZ_CVTSS_SD,
        ///<summary>Convert the single-precision (32-bit) floating-point value a to a half-precision (16-bit) floating-point value, and store the result in dst. ()</summary>
        _CVTSS_SH,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 32-bit integer, and store the result in dst. (SSE)</summary>
        _MM_CVTSS_SI32,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 64-bit integer, and store the result in dst. (SSE)</summary>
        _MM_CVTSS_SI64,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to an unsigned 32-bit integer, and store the result in dst. (AVX512F)</summary>
        _MM_CVTSS_U32,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to an unsigned 64-bit integer, and store the result in dst. (AVX512F)</summary>
        _MM_CVTSS_U64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst. (SSE)</summary>
        _MM_CVTT_PS2PI,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst.  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_CVTT_ROUNDPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_MASK_CVTT_ROUNDPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_MASKZ_CVTT_ROUNDPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst. Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512DQ)</summary>
        _MM512_CVTT_ROUNDPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512DQ)</summary>
        _MM512_MASK_CVTT_ROUNDPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512DQ)</summary>
        _MM512_MASKZ_CVTT_ROUNDPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst.  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_CVTT_ROUNDPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).   	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_MASK_CVTT_ROUNDPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_MASKZ_CVTT_ROUNDPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst. Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512DQ)</summary>
        _MM512_CVTT_ROUNDPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512DQ)</summary>
        _MM512_MASK_CVTT_ROUNDPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512DQ)</summary>
        _MM512_MASKZ_CVTT_ROUNDPD_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst.  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_CVTT_ROUNDPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_MASK_CVTT_ROUNDPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_MASKZ_CVTT_ROUNDPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst. Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512DQ)</summary>
        _MM512_CVTT_ROUNDPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512DQ)</summary>
        _MM512_MASK_CVTT_ROUNDPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512DQ)</summary>
        _MM512_MASKZ_CVTT_ROUNDPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst.  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_CVTT_ROUNDPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).   	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_MASK_CVTT_ROUNDPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512F)</summary>
        _MM512_MASKZ_CVTT_ROUNDPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst. Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512DQ)</summary>
        _MM512_CVTT_ROUNDPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set).  	Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512DQ)</summary>
        _MM512_MASK_CVTT_ROUNDPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). Pass __MM_FROUND_NO_EXC to sae to suppress all exceptions. (AVX512DQ)</summary>
        _MM512_MASKZ_CVTT_ROUNDPS_EPU64,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 32-bit integer with truncation, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVTT_ROUNDSD_I32,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 64-bit integer with truncation, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVTT_ROUNDSD_I64,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 32-bit integer with truncation, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVTT_ROUNDSD_SI32,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 64-bit integer with truncation, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVTT_ROUNDSD_SI64,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to an unsigned 32-bit integer with truncation, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVTT_ROUNDSD_U32,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to an unsigned 64-bit integer with truncation, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVTT_ROUNDSD_U64,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 32-bit integer with truncation, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVTT_ROUNDSS_I32,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 64-bit integer with truncation, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVTT_ROUNDSS_I64,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 32-bit integer with truncation, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVTT_ROUNDSS_SI32,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 64-bit integer with truncation, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVTT_ROUNDSS_SI64,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to an unsigned 32-bit integer with truncation, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVTT_ROUNDSS_U32,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to an unsigned 64-bit integer with truncation, and store the result in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_CVTT_ROUNDSS_U64,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 32-bit integer with truncation, and store the result in dst. (SSE)</summary>
        _MM_CVTT_SS2SI,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst. (SSE2)</summary>
        _MM_CVTTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst. (AVX)</summary>
        _MM256_CVTTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTTPD_EPI32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM_CVTTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_CVTTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_CVTTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_CVTTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_CVTTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_CVTTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst. (AVX512DQ)</summary>
        _MM512_CVTTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_CVTTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_CVTTPD_EPI64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTTPD_EPU32,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM_CVTTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_CVTTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_CVTTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_CVTTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_CVTTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_CVTTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst. (AVX512DQ)</summary>
        _MM512_CVTTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_CVTTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_CVTTPD_EPU64,
        ///<summary>Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst. (SSE2)</summary>
        _MM_CVTTPD_PI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst. (SSE2)</summary>
        _MM_CVTTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst. (AVX)</summary>
        _MM256_CVTTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTTPS_EPI32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM_CVTTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_CVTTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_CVTTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_CVTTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_CVTTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_CVTTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst. (AVX512DQ)</summary>
        _MM512_CVTTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_CVTTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_CVTTPS_EPI64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTTPS_EPU32,
        ///<summary>Convert packed double-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTTPS_EPU32,
        ///<summary>Convert packed double-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTTPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTTPS_EPU32,
        ///<summary>Convert packed double-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTTPS_EPU32,
        ///<summary>Convert packed double-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTTPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTTPS_EPU32,
        ///<summary>Convert packed double-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTTPS_EPU32,
        ///<summary>Convert packed double-precision (32-bit) floating-point elements in a to packed unsigned 32-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTTPS_EPU32,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM_CVTTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_CVTTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM_MASKZ_CVTTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_CVTTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_CVTTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_CVTTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst. (AVX512DQ)</summary>
        _MM512_CVTTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_CVTTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed unsigned 64-bit integers with truncation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_CVTTPS_EPU64,
        ///<summary>Convert packed single-precision (32-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst. (SSE)</summary>
        _MM_CVTTPS_PI32,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 32-bit integer with truncation, and store the result in dst. (AVX512F)</summary>
        _MM_CVTTSD_I32,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 64-bit integer with truncation, and store the result in dst. (AVX512F)</summary>
        _MM_CVTTSD_I64,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 32-bit integer with truncation, and store the result in dst. (SSE2)</summary>
        _MM_CVTTSD_SI32,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 64-bit integer with truncation, and store the result in dst. (SSE2)</summary>
        _MM_CVTTSD_SI64,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to a 64-bit integer with truncation, and store the result in dst. (SSE2)</summary>
        _MM_CVTTSD_SI64X,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to an unsigned 32-bit integer with truncation, and store the result in dst. (AVX512F)</summary>
        _MM_CVTTSD_U32,
        ///<summary>Convert the lower double-precision (64-bit) floating-point element in a to an unsigned 64-bit integer with truncation, and store the result in dst. (AVX512F)</summary>
        _MM_CVTTSD_U64,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 32-bit integer with truncation, and store the result in dst. (AVX512F)</summary>
        _MM_CVTTSS_I32,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 64-bit integer with truncation, and store the result in dst. (AVX512F)</summary>
        _MM_CVTTSS_I64,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 32-bit integer with truncation, and store the result in dst. (SSE)</summary>
        _MM_CVTTSS_SI32,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to a 64-bit integer with truncation, and store the result in dst. (SSE)</summary>
        _MM_CVTTSS_SI64,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to an unsigned 32-bit integer with truncation, and store the result in dst. (AVX512F)</summary>
        _MM_CVTTSS_U32,
        ///<summary>Convert the lower single-precision (32-bit) floating-point element in a to an unsigned 64-bit integer with truncation, and store the result in dst. (AVX512F)</summary>
        _MM_CVTTSS_U64,
        ///<summary>Convert the unsigned 32-bit integer b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_CVTU32_SD,
        ///<summary>Convert the unsigned 32-bit integer b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_CVTU32_SS,
        ///<summary>Convert the unsigned 64-bit integer b to a double-precision (64-bit) floating-point element, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_CVTU64_SD,
        ///<summary>Convert the unsigned 64-bit integer b to a single-precision (32-bit) floating-point element, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_CVTU64_SS,
        ///<summary>Convert packed unsigned 16-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst. (AVX512VL, AVX512BW)</summary>
        _MM_CVTUSEPI16_EPI8,
        ///<summary>Convert packed unsigned 16-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CVTUSEPI16_EPI8,
        ///<summary>Convert packed unsigned 16-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_CVTUSEPI16_EPI8,
        ///<summary>Convert packed unsigned 16-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst. (AVX512VL, AVX512BW)</summary>
        _MM256_CVTUSEPI16_EPI8,
        ///<summary>Convert packed unsigned 16-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CVTUSEPI16_EPI8,
        ///<summary>Convert packed unsigned 16-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_CVTUSEPI16_EPI8,
        ///<summary>Convert packed unsigned 16-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst. (AVX512BW)</summary>
        _MM512_CVTUSEPI16_EPI8,
        ///<summary>Convert packed unsigned 16-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASK_CVTUSEPI16_EPI8,
        ///<summary>Convert packed unsigned 16-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512BW)</summary>
        _MM512_MASKZ_CVTUSEPI16_EPI8,
        ///<summary>Convert packed unsigned 16-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512BW)</summary>
        _MM_MASK_CVTUSEPI16_STOREU_EPI8,
        ///<summary>Convert packed unsigned 16-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_CVTUSEPI16_STOREU_EPI8,
        ///<summary>Convert packed unsigned 16-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512BW)</summary>
        _MM512_MASK_CVTUSEPI16_STOREU_EPI8,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTUSEPI32_EPI16,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTUSEPI32_EPI16,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTUSEPI32_EPI16,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTUSEPI32_EPI16,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTUSEPI32_EPI16,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTUSEPI32_EPI16,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTUSEPI32_EPI16,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTUSEPI32_EPI16,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTUSEPI32_EPI16,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTUSEPI32_EPI8,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTUSEPI32_EPI8,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTUSEPI32_EPI8,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTUSEPI32_EPI8,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTUSEPI32_EPI8,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTUSEPI32_EPI8,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTUSEPI32_EPI8,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTUSEPI32_EPI8,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTUSEPI32_EPI8,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTUSEPI32_STOREU_EPI16,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTUSEPI32_STOREU_EPI16,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed 16-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTUSEPI32_STOREU_EPI16,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTUSEPI32_STOREU_EPI8,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTUSEPI32_STOREU_EPI8,
        ///<summary>Convert packed unsigned 32-bit integers in a to packed 8-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTUSEPI32_STOREU_EPI8,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTUSEPI64_EPI16,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTUSEPI64_EPI16,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTUSEPI64_EPI16,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTUSEPI64_EPI16,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTUSEPI64_EPI16,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTUSEPI64_EPI16,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTUSEPI64_EPI16,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTUSEPI64_EPI16,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTUSEPI64_EPI16,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 32-bit integers with unsigned saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTUSEPI64_EPI32,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 32-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTUSEPI64_EPI32,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 32-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTUSEPI64_EPI32,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 32-bit integers with unsigned saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTUSEPI64_EPI32,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 32-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTUSEPI64_EPI32,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 32-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTUSEPI64_EPI32,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 32-bit integers with unsigned saturation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTUSEPI64_EPI32,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 32-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTUSEPI64_EPI32,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 32-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTUSEPI64_EPI32,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM_CVTUSEPI64_EPI8,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTUSEPI64_EPI8,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_CVTUSEPI64_EPI8,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst. (AVX512VL, AVX512F)</summary>
        _MM256_CVTUSEPI64_EPI8,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTUSEPI64_EPI8,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_CVTUSEPI64_EPI8,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst. (AVX512F)</summary>
        _MM512_CVTUSEPI64_EPI8,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_CVTUSEPI64_EPI8,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_CVTUSEPI64_EPI8,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTUSEPI64_STOREU_EPI16,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 16-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTUSEPI64_STOREU_EPI16,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed 16-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTUSEPI64_STOREU_EPI16,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 32-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTUSEPI64_STOREU_EPI32,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 32-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTUSEPI64_STOREU_EPI32,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed 32-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTUSEPI64_STOREU_EPI32,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM_MASK_CVTUSEPI64_STOREU_EPI8,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed unsigned 8-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_CVTUSEPI64_STOREU_EPI8,
        ///<summary>Convert packed unsigned 64-bit integers in a to packed 8-bit integers with unsigned saturation, and store the active results (those with their respective bit set in writemask k) to unaligned memory at base_addr. (AVX512F)</summary>
        _MM512_MASK_CVTUSEPI64_STOREU_EPI8,
        ///<summary>Compute the sum of absolute differences (SADs) of quadruplets of unsigned 8-bit integers in a compared to those in b, and store the 16-bit results in dst. 	Four SADs are performed on four 8-bit quadruplets for each 64-bit lane. The first two SADs use the lower 8-bit quadruplet of the lane from a, and the last two SADs use the uppper 8-bit quadruplet of the lane from a. Quadruplets from b are selected according to the control in imm8, and each SAD in each 64-bit lane uses the selected quadruplet at 8-bit offsets. (AVX512VL, AVX512BW)</summary>
        _MM_DBSAD_EPU8,
        ///<summary>Compute the sum of absolute differences (SADs) of quadruplets of unsigned 8-bit integers in a compared to those in b, and store the 16-bit results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). 	Four SADs are performed on four 8-bit quadruplets for each 64-bit lane. The first two SADs use the lower 8-bit quadruplet of the lane from a, and the last two SADs use the uppper 8-bit quadruplet of the lane from a. Quadruplets from b are selected according to the control in imm8, and each SAD in each 64-bit lane uses the selected quadruplet at 8-bit offsets. (AVX512VL, AVX512BW)</summary>
        _MM_MASK_DBSAD_EPU8,
        ///<summary>Compute the sum of absolute differences (SADs) of quadruplets of unsigned 8-bit integers in a compared to those in b, and store the 16-bit results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Four SADs are performed on four 8-bit quadruplets for each 64-bit lane. The first two SADs use the lower 8-bit quadruplet of the lane from a, and the last two SADs use the uppper 8-bit quadruplet of the lane from a. Quadruplets from b are selected according to the control in imm8, and each SAD in each 64-bit lane uses the selected quadruplet at 8-bit offsets. (AVX512VL, AVX512BW)</summary>
        _MM_MASKZ_DBSAD_EPU8,
        ///<summary>Compute the sum of absolute differences (SADs) of quadruplets of unsigned 8-bit integers in a compared to those in b, and store the 16-bit results in dst. 	Four SADs are performed on four 8-bit quadruplets for each 64-bit lane. The first two SADs use the lower 8-bit quadruplet of the lane from a, and the last two SADs use the uppper 8-bit quadruplet of the lane from a. Quadruplets from b are selected from within 128-bit lanes according to the control in imm8, and each SAD in each 64-bit lane uses the selected quadruplet at 8-bit offsets. (AVX512VL, AVX512BW)</summary>
        _MM256_DBSAD_EPU8,
        ///<summary>Compute the sum of absolute differences (SADs) of quadruplets of unsigned 8-bit integers in a compared to those in b, and store the 16-bit results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). 	Four SADs are performed on four 8-bit quadruplets for each 64-bit lane. The first two SADs use the lower 8-bit quadruplet of the lane from a, and the last two SADs use the uppper 8-bit quadruplet of the lane from a. Quadruplets from b are selected from within 128-bit lanes according to the control in imm8, and each SAD in each 64-bit lane uses the selected quadruplet at 8-bit offsets. (AVX512VL, AVX512BW)</summary>
        _MM256_MASK_DBSAD_EPU8,
        ///<summary>Compute the sum of absolute differences (SADs) of quadruplets of unsigned 8-bit integers in a compared to those in b, and store the 16-bit results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Four SADs are performed on four 8-bit quadruplets for each 64-bit lane. The first two SADs use the lower 8-bit quadruplet of the lane from a, and the last two SADs use the uppper 8-bit quadruplet of the lane from a. Quadruplets from b are selected from within 128-bit lanes according to the control in imm8, and each SAD in each 64-bit lane uses the selected quadruplet at 8-bit offsets. (AVX512VL, AVX512BW)</summary>
        _MM256_MASKZ_DBSAD_EPU8,
        ///<summary>Compute the sum of absolute differences (SADs) of quadruplets of unsigned 8-bit integers in a compared to those in b, and store the 16-bit results in dst. 	Four SADs are performed on four 8-bit quadruplets for each 64-bit lane. The first two SADs use the lower 8-bit quadruplet of the lane from a, and the last two SADs use the uppper 8-bit quadruplet of the lane from a. Quadruplets from b are selected from within 128-bit lanes according to the control in imm8, and each SAD in each 64-bit lane uses the selected quadruplet at 8-bit offsets. (AVX512BW)</summary>
        _MM512_DBSAD_EPU8,
        ///<summary>Compute the sum of absolute differences (SADs) of quadruplets of unsigned 8-bit integers in a compared to those in b, and store the 16-bit results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). 	Four SADs are performed on four 8-bit quadruplets for each 64-bit lane. The first two SADs use the lower 8-bit quadruplet of the lane from a, and the last two SADs use the uppper 8-bit quadruplet of the lane from a. Quadruplets from b are selected from within 128-bit lanes according to the control in imm8, and each SAD in each 64-bit lane uses the selected quadruplet at 8-bit offsets. (AVX512BW)</summary>
        _MM512_MASK_DBSAD_EPU8,
        ///<summary>Compute the sum of absolute differences (SADs) of quadruplets of unsigned 8-bit integers in a compared to those in b, and store the 16-bit results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Four SADs are performed on four 8-bit quadruplets for each 64-bit lane. The first two SADs use the lower 8-bit quadruplet of the lane from a, and the last two SADs use the uppper 8-bit quadruplet of the lane from a. Quadruplets from b are selected from within 128-bit lanes according to the control in imm8, and each SAD in each 64-bit lane uses the selected quadruplet at 8-bit offsets. (AVX512BW)</summary>
        _MM512_MASKZ_DBSAD_EPU8,
        ///<summary>Stalls a thread without blocking other threads for 32-bit unsigned integer r1 clock cycles. (KNCNI)</summary>
        _MM_DELAY_32,
        ///<summary>Stalls a thread without blocking other threads for 64-bit unsigned integer r1 clock cycles. (KNCNI)</summary>
        _MM_DELAY_64,
        ///<summary>Divide packed 16-bit integers in a by packed elements in b, and store the truncated results in dst. (SSE)</summary>
        _MM_DIV_EPI16,
        ///<summary>Divide packed 16-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX)</summary>
        _MM256_DIV_EPI16,
        ///<summary>Divide packed 16-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX512F)</summary>
        _MM512_DIV_EPI16,
        ///<summary>Divide packed 32-bit integers in a by packed elements in b, and store the truncated results in dst. (SSE)</summary>
        _MM_DIV_EPI32,
        ///<summary>Divide packed 32-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX)</summary>
        _MM256_DIV_EPI32,
        ///<summary>Divide packed 32-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX512F)</summary>
        _MM512_DIV_EPI32,
        ///<summary>Divide packed 32-bit integers in a by packed elements in b, and store the truncated results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_DIV_EPI32,
        ///<summary>Divide packed 64-bit integers in a by packed elements in b, and store the truncated results in dst. (SSE)</summary>
        _MM_DIV_EPI64,
        ///<summary>Divide packed 64-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX)</summary>
        _MM256_DIV_EPI64,
        ///<summary>Divide packed 64-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX512F)</summary>
        _MM512_DIV_EPI64,
        ///<summary>Divide packed 8-bit integers in a by packed elements in b, and store the truncated results in dst. (SSE)</summary>
        _MM_DIV_EPI8,
        ///<summary>Divide packed 8-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX)</summary>
        _MM256_DIV_EPI8,
        ///<summary>Divide packed 8-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX512F)</summary>
        _MM512_DIV_EPI8,
        ///<summary>Divide packed unsigned 16-bit integers in a by packed elements in b, and store the truncated results in dst. (SSE)</summary>
        _MM_DIV_EPU16,
        ///<summary>Divide packed unsigned 16-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX)</summary>
        _MM256_DIV_EPU16,
        ///<summary>Divide packed unsigned 16-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX512F)</summary>
        _MM512_DIV_EPU16,
        ///<summary>Divide packed unsigned 32-bit integers in a by packed elements in b, and store the truncated results in dst. (SSE)</summary>
        _MM_DIV_EPU32,
        ///<summary>Divide packed unsigned 32-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX)</summary>
        _MM256_DIV_EPU32,
        ///<summary>Divide packed unsigned 32-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX512F)</summary>
        _MM512_DIV_EPU32,
        ///<summary>Divide packed unsigned 32-bit integers in a by packed elements in b, and store the truncated results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_DIV_EPU32,
        ///<summary>Divide packed unsigned 64-bit integers in a by packed elements in b, and store the truncated results in dst. (SSE)</summary>
        _MM_DIV_EPU64,
        ///<summary>Divide packed unsigned 64-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX)</summary>
        _MM256_DIV_EPU64,
        ///<summary>Divide packed unsigned 64-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX512F)</summary>
        _MM512_DIV_EPU64,
        ///<summary>Divide packed unsigned 8-bit integers in a by packed elements in b, and store the truncated results in dst. (SSE)</summary>
        _MM_DIV_EPU8,
        ///<summary>Divide packed unsigned 8-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX)</summary>
        _MM256_DIV_EPU8,
        ///<summary>Divide packed unsigned 8-bit integers in a by packed elements in b, and store the truncated results in dst. (AVX512F)</summary>
        _MM512_DIV_EPU8,
        ///<summary>Divide packed double-precision (64-bit) floating-point elements in a by packed elements in b, and store the results in dst. (SSE2)</summary>
        _MM_DIV_PD,
        ///<summary>Divide packed double-precision (64-bit) floating-point elements in a by packed elements in b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_DIV_PD,
        ///<summary>Divide packed double-precision (64-bit) floating-point elements in a by packed elements in b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_DIV_PD,
        ///<summary>Divide packed double-precision (64-bit) floating-point elements in a by packed elements in b, and store the results in dst. (AVX)</summary>
        _MM256_DIV_PD,
        ///<summary>Divide packed double-precision (64-bit) floating-point elements in a by packed elements in b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_DIV_PD,
        ///<summary>Divide packed double-precision (64-bit) floating-point elements in a by packed elements in b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_DIV_PD,
        ///<summary>Divide packed double-precision (64-bit) floating-point elements in a by packed elements in b, and store the results in dst. (AVX512F)</summary>
        _MM512_DIV_PD,
        ///<summary>Divide packed double-precision (64-bit) floating-point elements in a by packed elements in b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_DIV_PD,
        ///<summary>Divide packed double-precision (64-bit) floating-point elements in a by packed elements in b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_DIV_PD,
        ///<summary>Divide packed single-precision (32-bit) floating-point elements in a by packed elements in b, and store the results in dst. (SSE)</summary>
        _MM_DIV_PS,
        ///<summary>Divide packed single-precision (32-bit) floating-point elements in a by packed elements in b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_DIV_PS,
        ///<summary>Divide packed single-precision (32-bit) floating-point elements in a by packed elements in b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_DIV_PS,
        ///<summary>Divide packed single-precision (32-bit) floating-point elements in a by packed elements in b, and store the results in dst. (AVX)</summary>
        _MM256_DIV_PS,
        ///<summary>Divide packed single-precision (32-bit) floating-point elements in a by packed elements in b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_DIV_PS,
        ///<summary>Divide packed single-precision (32-bit) floating-point elements in a by packed elements in b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_DIV_PS,
        ///<summary>Divide packed single-precision (32-bit) floating-point elements in a by packed elements in b, and store the results in dst. (AVX512F)</summary>
        _MM512_DIV_PS,
        ///<summary>Divide packed single-precision (32-bit) floating-point elements in a by packed elements in b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_DIV_PS,
        ///<summary>Divide packed single-precision (32-bit) floating-point elements in a by packed elements in b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_DIV_PS,
        ///<summary>Divide packed double-precision (64-bit) floating-point elements in a by packed elements in b, =and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_DIV_ROUND_PD,
        ///<summary>Divide packed double-precision (64-bit) floating-point elements in a by packed elements in b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_DIV_ROUND_PD,
        ///<summary>Divide packed double-precision (64-bit) floating-point elements in a by packed elements in b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_DIV_ROUND_PD,
        ///<summary>Divide packed single-precision (32-bit) floating-point elements in a by packed elements in b, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_DIV_ROUND_PS,
        ///<summary>Divide packed single-precision (32-bit) floating-point elements in a by packed elements in b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_DIV_ROUND_PS,
        ///<summary>Divide packed single-precision (32-bit) floating-point elements in a by packed elements in b, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_DIV_ROUND_PS,
        ///<summary>Divide the lower double-precision (64-bit) floating-point element in a by the lower double-precision (64-bit) floating-point element in b, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. 		Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_DIV_ROUND_SD,
        ///<summary>Divide the lower double-precision (64-bit) floating-point element in a by the lower double-precision (64-bit) floating-point element in b, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper element from a to the upper element of dst.  		Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_DIV_ROUND_SD,
        ///<summary>Divide the lower double-precision (64-bit) floating-point element in a by the lower double-precision (64-bit) floating-point element in b, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 		Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_DIV_ROUND_SD,
        ///<summary>Divide the lower single-precision (32-bit) floating-point element in a by the lower single-precision (32-bit) floating-point element in b, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. 		Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_DIV_ROUND_SS,
        ///<summary>Divide the lower single-precision (32-bit) floating-point element in a by the lower single-precision (32-bit) floating-point element in b, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst.  		Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_DIV_ROUND_SS,
        ///<summary>Divide the lower single-precision (32-bit) floating-point element in a by the lower single-precision (32-bit) floating-point element in b, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. 		Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_DIV_ROUND_SS,
        ///<summary>Divide the lower double-precision (64-bit) floating-point element in a by the lower double-precision (64-bit) floating-point element in b, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE2)</summary>
        _MM_DIV_SD,
        ///<summary>Divide the lower double-precision (64-bit) floating-point element in a by the lower double-precision (64-bit) floating-point element in b, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASK_DIV_SD,
        ///<summary>Divide the lower double-precision (64-bit) floating-point element in a by the lower double-precision (64-bit) floating-point element in b, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASKZ_DIV_SD,
        ///<summary>Divide the lower single-precision (32-bit) floating-point element in a by the lower single-precision (32-bit) floating-point element in b, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE)</summary>
        _MM_DIV_SS,
        ///<summary>Divide the lower single-precision (32-bit) floating-point element in a by the lower single-precision (32-bit) floating-point element in b, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASK_DIV_SS,
        ///<summary>Divide the lower single-precision (32-bit) floating-point element in a by the lower single-precision (32-bit) floating-point element in b, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASKZ_DIV_SS,
        ///<summary>Conditionally multiply the packed double-precision (64-bit) floating-point elements in a and b using the high 4 bits in imm8, sum the four products, and conditionally store the sum in dst using the low 4 bits of imm8. (SSE4.1)</summary>
        _MM_DP_PD,
        ///<summary>Conditionally multiply the packed single-precision (32-bit) floating-point elements in a and b using the high 4 bits in imm8, sum the four products, and conditionally store the sum in dst using the low 4 bits of imm8. (SSE4.1)</summary>
        _MM_DP_PS,
        ///<summary>Conditionally multiply the packed single-precision (32-bit) floating-point elements in a and b using the high 4 bits in imm8, sum the four products, and conditionally store the sum in dst using the low 4 bits of imm8. (AVX)</summary>
        _MM256_DP_PS,
        ///<summary>Empty the MMX state, which marks the x87 FPU registers as available for use by x87 instructions. This instruction must be used at the end of all MMX technology procedures. (MMX)</summary>
        _M_EMPTY,
        ///<summary>Empty the MMX state, which marks the x87 FPU registers as available for use by x87 instructions. This instruction must be used at the end of all MMX technology procedures. (MMX)</summary>
        _MM_EMPTY,
        ///<summary>Compute the error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_ERF_PD,
        ///<summary>Compute the error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_ERF_PD,
        ///<summary>Compute the error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_ERF_PD,
        ///<summary>Compute the error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ERF_PD,
        ///<summary>Compute the error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_ERF_PS,
        ///<summary>Compute the error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_ERF_PS,
        ///<summary>Compute the error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_ERF_PS,
        ///<summary>Compute the error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ERF_PS,
        ///<summary>Compute the complementary error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_ERFC_PD,
        ///<summary>Compute the complementary error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_ERFC_PD,
        ///<summary>Compute the complementary error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_ERFC_PD,
        ///<summary>Compute the complementary error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ERFC_PD,
        ///<summary>Compute the complementary error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_ERFC_PS,
        ///<summary>Compute the complementary error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_ERFC_PS,
        ///<summary>Compute the complementary error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_ERFC_PS,
        ///<summary>Compute the complementary error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ERFC_PS,
        ///<summary>Compute the inverse complementary error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_ERFCINV_PD,
        ///<summary>Compute the inverse complementary error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_ERFCINV_PD,
        ///<summary>Compute the inverse complementary error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_ERFCINV_PD,
        ///<summary>Compute the inverse complementary error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ERFCINV_PD,
        ///<summary>Compute the inverse complementary error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_ERFCINV_PS,
        ///<summary>Compute the inverse complementary error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_ERFCINV_PS,
        ///<summary>Compute the inverse complementary error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_ERFCINV_PS,
        ///<summary>Compute the inverse complementary error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ERFCINV_PS,
        ///<summary>Compute the inverse error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_ERFINV_PD,
        ///<summary>Compute the inverse error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_ERFINV_PD,
        ///<summary>Compute the inverse error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_ERFINV_PD,
        ///<summary>Compute the inverse error function of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ERFINV_PD,
        ///<summary>Compute the inverse error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_ERFINV_PS,
        ///<summary>Compute the inverse error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_ERFINV_PS,
        ///<summary>Compute the inverse error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_ERFINV_PS,
        ///<summary>Compute the inverse error function of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_ERFINV_PS,
        ///<summary>Compute the exponential value of e raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_EXP_PD,
        ///<summary>Compute the exponential value of e raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_EXP_PD,
        ///<summary>Compute the exponential value of e raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_EXP_PD,
        ///<summary>Compute the exponential value of e raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXP_PD,
        ///<summary>Compute the exponential value of e raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_EXP_PS,
        ///<summary>Compute the exponential value of e raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_EXP_PS,
        ///<summary>Compute the exponential value of e raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_EXP_PS,
        ///<summary>Compute the exponential value of e raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXP_PS,
        ///<summary>Compute the exponential value of 10 raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_EXP10_PD,
        ///<summary>Compute the exponential value of 10 raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_EXP10_PD,
        ///<summary>Compute the exponential value of 10 raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_EXP10_PD,
        ///<summary>Compute the exponential value of 10 raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXP10_PD,
        ///<summary>Compute the exponential value of 10 raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_EXP10_PS,
        ///<summary>Compute the exponential value of 10 raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_EXP10_PS,
        ///<summary>Compute the exponential value of 10 raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_EXP10_PS,
        ///<summary>Compute the exponential value of 10 raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXP10_PS,
        ///<summary>Compute the exponential value of 2 raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_EXP2_PD,
        ///<summary>Compute the exponential value of 2 raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_EXP2_PD,
        ///<summary>Compute the exponential value of 2 raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_EXP2_PD,
        ///<summary>Compute the exponential value of 2 raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXP2_PD,
        ///<summary>Compute the exponential value of 2 raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (SSE)</summary>
        _MM_EXP2_PS,
        ///<summary>Compute the exponential value of 2 raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX)</summary>
        _MM256_EXP2_PS,
        ///<summary>Compute the exponential value of 2 raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. (AVX512F)</summary>
        _MM512_EXP2_PS,
        ///<summary>Compute the exponential value of 2 raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXP2_PS,
        ///<summary>Approximates the base-2 exponent of the packed single-precision (32-bit) floating-point elements in v2 with eight bits for sign and magnitude and 24 bits for the fractional part. Results are stored in dst. (KNCNI)</summary>
        _MM512_EXP223_PS,
        ///<summary>Approximates the base-2 exponent of the packed single-precision (32-bit) floating-point elements in v2 with eight bits for sign and magnitude and 24 bits for the fractional part. Results are stored in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXP223_PS,
        ///<summary>Compute the approximate exponential value of 2 raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. The maximum relative error for this approximation is less than 2^-23. (AVX512ER)</summary>
        _MM512_EXP2A23_PD,
        ///<summary>Compute the approximate exponential value of 2 raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). The maximum relative error for this approximation is less than 2^-23. (AVX512ER)</summary>
        _MM512_MASK_EXP2A23_PD,
        ///<summary>Compute the approximate exponential value of 2 raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). The maximum relative error for this approximation is less than 2^-23. (AVX512ER)</summary>
        _MM512_MASKZ_EXP2A23_PD,
        ///<summary>Compute the approximate exponential value of 2 raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. The maximum relative error for this approximation is less than 2^-23. (AVX512ER)</summary>
        _MM512_EXP2A23_PS,
        ///<summary>Compute the approximate exponential value of 2 raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). The maximum relative error for this approximation is less than 2^-23. (AVX512ER)</summary>
        _MM512_MASK_EXP2A23_PS,
        ///<summary>Compute the approximate exponential value of 2 raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). The maximum relative error for this approximation is less than 2^-23. (AVX512ER)</summary>
        _MM512_MASKZ_EXP2A23_PS,
        ///<summary>Compute the approximate exponential value of 2 raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. The maximum relative error for this approximation is less than 2^-23. Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512ER)</summary>
        _MM512_EXP2A23_ROUND_PD,
        ///<summary>Compute the approximate exponential value of 2 raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). The maximum relative error for this approximation is less than 2^-23. Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512ER)</summary>
        _MM512_MASK_EXP2A23_ROUND_PD,
        ///<summary>Compute the approximate exponential value of 2 raised to the power of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). The maximum relative error for this approximation is less than 2^-23. Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512ER)</summary>
        _MM512_MASKZ_EXP2A23_ROUND_PD,
        ///<summary>Compute the approximate exponential value of 2 raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. The maximum relative error for this approximation is less than 2^-23. Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512ER)</summary>
        _MM512_EXP2A23_ROUND_PS,
        ///<summary>Compute the approximate exponential value of 2 raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). The maximum relative error for this approximation is less than 2^-23. Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512ER)</summary>
        _MM512_MASK_EXP2A23_ROUND_PS,
        ///<summary>Compute the approximate exponential value of 2 raised to the power of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). The maximum relative error for this approximation is less than 2^-23. Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512ER)</summary>
        _MM512_MASKZ_EXP2A23_ROUND_PS,
        ///<summary>Load contiguous active 32-bit integers from a (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_EXPAND_EPI32,
        ///<summary>Load contiguous active 32-bit integers from a (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_EXPAND_EPI32,
        ///<summary>Load contiguous active 32-bit integers from a (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_EXPAND_EPI32,
        ///<summary>Load contiguous active 32-bit integers from a (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_EXPAND_EPI32,
        ///<summary>Load contiguous active 32-bit integers from a (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXPAND_EPI32,
        ///<summary>Load contiguous active 32-bit integers from a (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_EXPAND_EPI32,
        ///<summary>Load contiguous active 64-bit integers from a (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_EXPAND_EPI64,
        ///<summary>Load contiguous active 64-bit integers from a (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_EXPAND_EPI64,
        ///<summary>Load contiguous active 64-bit integers from a (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_EXPAND_EPI64,
        ///<summary>Load contiguous active 64-bit integers from a (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_EXPAND_EPI64,
        ///<summary>Load contiguous active 64-bit integers from a (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXPAND_EPI64,
        ///<summary>Load contiguous active 64-bit integers from a (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_EXPAND_EPI64,
        ///<summary>Load contiguous active double-precision (64-bit) floating-point elements from a (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_EXPAND_PD,
        ///<summary>Load contiguous active double-precision (64-bit) floating-point elements from a (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_EXPAND_PD,
        ///<summary>Load contiguous active double-precision (64-bit) floating-point elements from a (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_EXPAND_PD,
        ///<summary>Load contiguous active double-precision (64-bit) floating-point elements from a (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_EXPAND_PD,
        ///<summary>Load contiguous active double-precision (64-bit) floating-point elements from a (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXPAND_PD,
        ///<summary>Load contiguous active double-precision (64-bit) floating-point elements from a (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_EXPAND_PD,
        ///<summary>Load contiguous active single-precision (32-bit) floating-point elements from a (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_EXPAND_PS,
        ///<summary>Load contiguous active single-precision (32-bit) floating-point elements from a (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_EXPAND_PS,
        ///<summary>Load contiguous active single-precision (32-bit) floating-point elements from a (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_EXPAND_PS,
        ///<summary>Load contiguous active single-precision (32-bit) floating-point elements from a (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_EXPAND_PS,
        ///<summary>Load contiguous active single-precision (32-bit) floating-point elements from a (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXPAND_PS,
        ///<summary>Load contiguous active single-precision (32-bit) floating-point elements from a (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_EXPAND_PS,
        ///<summary>Load contiguous active 32-bit integers from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_EXPANDLOADU_EPI32,
        ///<summary>Load contiguous active 32-bit integers from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_EXPANDLOADU_EPI32,
        ///<summary>Load contiguous active 32-bit integers from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_EXPANDLOADU_EPI32,
        ///<summary>Load contiguous active 32-bit integers from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_EXPANDLOADU_EPI32,
        ///<summary>Load contiguous active 32-bit integers from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXPANDLOADU_EPI32,
        ///<summary>Load contiguous active 32-bit integers from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_EXPANDLOADU_EPI32,
        ///<summary>Load contiguous active 64-bit integers from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_EXPANDLOADU_EPI64,
        ///<summary>Load contiguous active 64-bit integers from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_EXPANDLOADU_EPI64,
        ///<summary>Load contiguous active 64-bit integers from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_EXPANDLOADU_EPI64,
        ///<summary>Load contiguous active 64-bit integers from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_EXPANDLOADU_EPI64,
        ///<summary>Load contiguous active 64-bit integers from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXPANDLOADU_EPI64,
        ///<summary>Load contiguous active 64-bit integers from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_EXPANDLOADU_EPI64,
        ///<summary>Load contiguous active double-precision (64-bit) floating-point elements from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_EXPANDLOADU_PD,
        ///<summary>Load contiguous active double-precision (64-bit) floating-point elements from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_EXPANDLOADU_PD,
        ///<summary>Load contiguous active double-precision (64-bit) floating-point elements from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_EXPANDLOADU_PD,
        ///<summary>Load contiguous active double-precision (64-bit) floating-point elements from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_EXPANDLOADU_PD,
        ///<summary>Load contiguous active double-precision (64-bit) floating-point elements from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXPANDLOADU_PD,
        ///<summary>Load contiguous active double-precision (64-bit) floating-point elements from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_EXPANDLOADU_PD,
        ///<summary>Load contiguous active single-precision (32-bit) floating-point elements from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_EXPANDLOADU_PS,
        ///<summary>Load contiguous active single-precision (32-bit) floating-point elements from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_EXPANDLOADU_PS,
        ///<summary>Load contiguous active single-precision (32-bit) floating-point elements from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_EXPANDLOADU_PS,
        ///<summary>Load contiguous active single-precision (32-bit) floating-point elements from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_EXPANDLOADU_PS,
        ///<summary>Load contiguous active single-precision (32-bit) floating-point elements from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXPANDLOADU_PS,
        ///<summary>Load contiguous active single-precision (32-bit) floating-point elements from unaligned memory at mem_addr (those with their respective bit set in mask k), and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_EXPANDLOADU_PS,
        ///<summary>Compute the exponential value of e raised to the power of packed double-precision (64-bit) floating-point elements in a, subtract one from each element, and store the results in dst. (SSE)</summary>
        _MM_EXPM1_PD,
        ///<summary>Compute the exponential value of e raised to the power of packed double-precision (64-bit) floating-point elements in a, subtract one from each element, and store the results in dst. (AVX)</summary>
        _MM256_EXPM1_PD,
        ///<summary>Compute the exponential value of e raised to the power of packed double-precision (64-bit) floating-point elements in a, subtract one from each element, and store the results in dst. (AVX512F)</summary>
        _MM512_EXPM1_PD,
        ///<summary>Compute the exponential value of e raised to the power of packed double-precision (64-bit) floating-point elements in a, subtract one from each element, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXPM1_PD,
        ///<summary>Compute the exponential value of e raised to the power of packed single-precision (32-bit) floating-point elements in a, subtract one from each element, and store the results in dst. (SSE)</summary>
        _MM_EXPM1_PS,
        ///<summary>Compute the exponential value of e raised to the power of packed single-precision (32-bit) floating-point elements in a, subtract one from each element, and store the results in dst. (AVX)</summary>
        _MM256_EXPM1_PS,
        ///<summary>Compute the exponential value of e raised to the power of packed single-precision (32-bit) floating-point elements in a, subtract one from each element, and store the results in dst. (AVX512F)</summary>
        _MM512_EXPM1_PS,
        ///<summary>Compute the exponential value of e raised to the power of packed single-precision (32-bit) floating-point elements in a, subtract one from each element, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXPM1_PS,
        ///<summary>Depending on bc, loads 1, 4, or 16 elements of type and size determined by conv from memory address mt and converts all elements to 32-bit integer elements, storing the results in dst. hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTLOAD_EPI32,
        ///<summary>Depending on bc, loads 1, 4, or 16 elements of type and size determined by conv from memory address mt and converts all elements to 32-bit integer elements, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_MASK_EXTLOAD_EPI32,
        ///<summary>Depending on bc, loads 1, 4, or 8 elements of type and size determined by conv from memory address mt and converts all elements to 64-bit integer elements, storing the results in dst. hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTLOAD_EPI64,
        ///<summary>Depending on bc, loads 1, 4, or 8 elements of type and size determined by conv from memory address mt and converts all elements to 64-bit integer elements, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_MASK_EXTLOAD_EPI64,
        ///<summary>Depending on bc, loads 1, 4, or 8 elements of type and size determined by conv from memory address mt and converts all elements to double-precision (64-bit) floating-point elements, storing the results in dst. hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTLOAD_PD,
        ///<summary>Depending on bc, loads 1, 4, or 8 elements of type and size determined by conv from memory address mt and converts all elements to double-precision (64-bit) floating-point elements, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_MASK_EXTLOAD_PD,
        ///<summary>Depending on bc, loads 1, 4, or 16 elements of type and size determined by conv from memory address mt and converts all elements to single-precision (32-bit) floating-point elements, storing the results in dst. hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTLOAD_PS,
        ///<summary>Depending on bc, loads 1, 4, or 16 elements of type and size determined by conv from memory address mt and converts all elements to single-precision (32-bit) floating-point elements, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_MASK_EXTLOAD_PS,
        ///<summary>Loads the high-64-byte-aligned portion of the byte/word/doubleword stream starting at element-aligned address mt-64, up-converted depending on the value of conv, and expanded into packed 32-bit integers in dst. The initial values of dst are copied from src. Only those converted doublewords that occur at or after the first 64-byte-aligned address following (mt-64) are loaded. Elements in the resulting vector that do not map to those doublewords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. (KNCNI)</summary>
        _MM512_EXTLOADUNPACKHI_EPI32,
        ///<summary>Loads the high-64-byte-aligned portion of the byte/word/doubleword stream starting at element-aligned address mt-64, up-converted depending on the value of conv, and expanded into packed 32-bit integers in dst. The initial values of dst are copied from src. Only those converted doublewords that occur at or after the first 64-byte-aligned address following (mt-64) are loaded. Elements in the resulting vector that do not map to those doublewords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. Elements are copied to dst according to element selector k (elements are skipped when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTLOADUNPACKHI_EPI32,
        ///<summary>Loads the high-64-byte-aligned portion of the quadword stream starting at element-aligned address mt-64, up-converted depending on the value of conv, and expanded into packed 64-bit integers in dst. The initial values of dst are copied from src. Only those converted quadwords that occur at or after the first 64-byte-aligned address following (mt-64) are loaded. Elements in the resulting vector that do not map to those quadwords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. (KNCNI)</summary>
        _MM512_EXTLOADUNPACKHI_EPI64,
        ///<summary>Loads the high-64-byte-aligned portion of the quadword stream starting at element-aligned address mt-64, up-converted depending on the value of conv, and expanded into packed 64-bit integers in dst. The initial values of dst are copied from src. Only those converted quadwords that occur at or after the first 64-byte-aligned address following (mt-64) are loaded. Elements in the resulting vector that do not map to those quadwords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. Elements are copied to dst according to element selector k (elements are skipped when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTLOADUNPACKHI_EPI64,
        ///<summary>Loads the high-64-byte-aligned portion of the quadword stream starting at element-aligned address mt-64, up-converted depending on the value of conv, and expanded into packed double-precision (64-bit) floating-point values in dst. The initial values of dst are copied from src. Only those converted quadwords that occur at or after the first 64-byte-aligned address following (mt-64) are loaded. Elements in the resulting vector that do not map to those quadwords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. (KNCNI)</summary>
        _MM512_EXTLOADUNPACKHI_PD,
        ///<summary>Loads the high-64-byte-aligned portion of the quadword stream starting at element-aligned address mt-64, up-converted depending on the value of conv, and expanded into packed double-precision (64-bit) floating-point values in dst. The initial values of dst are copied from src. Only those converted quadwords that occur at or after the first 64-byte-aligned address following (mt-64) are loaded. Elements in the resulting vector that do not map to those quadwords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. Elements are copied to dst according to element selector k (elements are skipped when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTLOADUNPACKHI_PD,
        ///<summary>Loads the high-64-byte-aligned portion of the byte/word/doubleword stream starting at element-aligned address mt-64, up-converted depending on the value of conv, and expanded into packed single-precision (32-bit) floating-point elements in dst. The initial values of dst are copied from src. Only those converted quadwords that occur at or after the first 64-byte-aligned address following (mt-64) are loaded. Elements in the resulting vector that do not map to those quadwords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. (KNCNI)</summary>
        _MM512_EXTLOADUNPACKHI_PS,
        ///<summary>Loads the high-64-byte-aligned portion of the byte/word/doubleword stream starting at element-aligned address mt-64, up-converted depending on the value of conv, and expanded into packed single-precision (32-bit) floating-point elements in dst. The initial values of dst are copied from src. Only those converted quadwords that occur at or after the first 64-byte-aligned address following (mt-64) are loaded. Elements in the resulting vector that do not map to those quadwords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. Elements are copied to dst according to element selector k (elements are skipped when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTLOADUNPACKHI_PS,
        ///<summary>Loads the low-64-byte-aligned portion of the byte/word/doubleword stream starting at element-aligned address mt, up-converted depending on the value of conv, and expanded into packed 32-bit integers in dst. The initial values of dst are copied from src. Only those converted doublewords that occur before first 64-byte-aligned address following mt are loaded. Elements in the resulting vector that do not map to those doublewords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. (KNCNI)</summary>
        _MM512_EXTLOADUNPACKLO_EPI32,
        ///<summary>Loads the low-64-byte-aligned portion of the byte/word/doubleword stream starting at element-aligned address mt, up-converted depending on the value of conv, and expanded into packed 32-bit integers in dst. The initial values of dst are copied from src. Only those converted doublewords that occur before first 64-byte-aligned address following mt are loaded. Elements in the resulting vector that do not map to those doublewords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. Elements are copied to dst according to element selector k (elements are skipped when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTLOADUNPACKLO_EPI32,
        ///<summary>Loads the low-64-byte-aligned portion of the quadword stream starting at element-aligned address mt, up-converted depending on the value of conv, and expanded into packed 64-bit integers in dst. The initial values of dst are copied from src. Only those converted quad that occur before first 64-byte-aligned address following mt are loaded. Elements in the resulting vector that do not map to those quadwords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. (KNCNI)</summary>
        _MM512_EXTLOADUNPACKLO_EPI64,
        ///<summary>Loads the low-64-byte-aligned portion of the quadword stream starting at element-aligned address mt, up-converted depending on the value of conv, and expanded into packed 64-bit integers in dst. The initial values of dst are copied from src. Only those converted quadwords that occur before first 64-byte-aligned address following mt are loaded. Elements in the resulting vector that do not map to those quadwords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. Elements are copied to dst according to element selector k (elements are skipped when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTLOADUNPACKLO_EPI64,
        ///<summary>Loads the low-64-byte-aligned portion of the quadword stream starting at element-aligned address mt, up-converted depending on the value of conv, and expanded into packed double-precision (64-bit) floating-point elements in dst. The initial values of dst are copied from src. Only those converted quad that occur before first 64-byte-aligned address following mt are loaded. Elements in the resulting vector that do not map to those quadwords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. (KNCNI)</summary>
        _MM512_EXTLOADUNPACKLO_PD,
        ///<summary>Loads the low-64-byte-aligned portion of the quadword stream starting at element-aligned address mt, up-converted depending on the value of conv, and expanded into packed double-precision (64-bit) floating-point elements in dst. The initial values of dst are copied from src. Only those converted quad that occur before first 64-byte-aligned address following mt are loaded. Elements in the resulting vector that do not map to those quadwords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. Elements are copied to dst according to element selector k (elemenst are skipped when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTLOADUNPACKLO_PD,
        ///<summary>Loads the low-64-byte-aligned portion of the byte/word/doubleword stream starting at element-aligned address mt, up-converted depending on the value of conv, and expanded into packed single-precision (32-bit) floating-point elements in dst. The initial values of dst are copied from src. Only those converted doublewords that occur before first 64-byte-aligned address following mt are loaded. Elements in the resulting vector that do not map to those doublewords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. (KNCNI)</summary>
        _MM512_EXTLOADUNPACKLO_PS,
        ///<summary>Loads the low-64-byte-aligned portion of the byte/word/doubleword stream starting at element-aligned address mt, up-converted depending on the value of conv, and expanded into packed single-precision (32-bit) floating-point elements in dst. The initial values of dst are copied from src. Only those converted doublewords that occur before first 64-byte-aligned address following mt are loaded. Elements in the resulting vector that do not map to those doublewords are taken from src. hint indicates to the processor whether the loaded data is non-temporal. Elements are copied to dst according to element selector k (elements are skipped when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTLOADUNPACKLO_PS,
        ///<summary>Down-converts and stores packed 32-bit integer elements of v1 into a byte/word/doubleword stream according to conv at a logically mapped starting address (mt-64), storing the high-64-byte elements of that stream (those elemetns of the stream that map at or after the first 64-byte-aligned address following (m5-64)). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTPACKSTOREHI_EPI32,
        ///<summary>Down-converts and stores packed 32-bit integer elements of v1 into a byte/word/doubleword stream according to conv at a logically mapped starting address (mt-64), storing the high-64-byte elements of that stream (those elemetns of the stream that map at or after the first 64-byte-aligned address following (m5-64)). hint indicates to the processor whether the data is non-temporal. Elements are stored to memory according to element selector k (elements are skipped when the corresonding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTPACKSTOREHI_EPI32,
        ///<summary>Down-converts and stores packed 64-bit integer elements of v1 into a quadword stream according to conv at a logically mapped starting address (mt-64), storing the high-64-byte elements of that stream (those elemetns of the stream that map at or after the first 64-byte-aligned address following (m5-64)). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTPACKSTOREHI_EPI64,
        ///<summary>Down-converts and stores packed 64-bit integer elements of v1 into a quadword stream according to conv at a logically mapped starting address (mt-64), storing the high-64-byte elements of that stream (those elemetns of the stream that map at or after the first 64-byte-aligned address following (mt-64)). hint indicates to the processor whether the data is non-temporal. Elements are stored to memory according to element selector k (elements are skipped when the corresonding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTPACKSTOREHI_EPI64,
        ///<summary>Down-converts and stores packed double-precision (64-bit) floating-point elements of v1 into a quadword stream according to conv at a logically mapped starting address (mt-64), storing the high-64-byte elements of that stream (those elemetns of the stream that map at or after the first 64-byte-aligned address following (m5-64)). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTPACKSTOREHI_PD,
        ///<summary>Down-converts and stores packed double-precision (64-bit) floating-point elements of v1 into a quadword stream according to conv at a logically mapped starting address (mt-64), storing the high-64-byte elements of that stream (those elemetns of the stream that map at or after the first 64-byte-aligned address following (m5-64)). hint indicates to the processor whether the data is non-temporal. Elements are stored to memory according to element selector k (elements are skipped when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTPACKSTOREHI_PD,
        ///<summary>Down-converts and stores packed single-precision (32-bit) floating-point elements of v1 into a byte/word/doubleword stream according to conv at a logically mapped starting address (mt-64), storing the high-64-byte elements of that stream (those elemetns of the stream that map at or after the first 64-byte-aligned address following (m5-64)). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTPACKSTOREHI_PS,
        ///<summary>Down-converts and stores packed single-precision (32-bit) floating-point elements of v1 into a byte/word/doubleword stream according to conv at a logically mapped starting address (mt-64), storing the high-64-byte elements of that stream (those elemetns of the stream that map at or after the first 64-byte-aligned address following (m5-64)). hint indicates to the processor whether the data is non-temporal. Elements are stored to memory according to element selector k (elements are skipped when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTPACKSTOREHI_PS,
        ///<summary>Down-converts and stores packed 32-bit integer elements of v1 into a byte/word/doubleword stream according to conv at a logically mapped starting address mt, storing the low-64-byte elements of that stream (those elements of the stream that map before the first 64-byte-aligned address follwing mt). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTPACKSTORELO_EPI32,
        ///<summary>Down-converts and stores packed 32-bit integer elements of v1 into a byte/word/doubleword stream according to conv at a logically mapped starting address mt, storing the low-64-byte elements of that stream (those elements of the stream that map before the first 64-byte-aligned address follwing mt). hint indicates to the processor whether the data is non-temporal. Elements are written to memory according to element selector k (elements are skipped when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTPACKSTORELO_EPI32,
        ///<summary>Down-converts and stores packed 64-bit integer elements of v1 into a quadword stream according to conv at a logically mapped starting address mt, storing the low-64-byte elements of that stream (those elements of the stream that map before the first 64-byte-aligned address follwing mt). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTPACKSTORELO_EPI64,
        ///<summary>Down-converts and stores packed 64-bit integer elements of v1 into a quadword stream according to conv at a logically mapped starting address mt, storing the low-64-byte elements of that stream (those elements of the stream that map before the first 64-byte-aligned address follwing mt). hint indicates to the processor whether the data is non-temporal. Elements are stored to memory according to element selector k (elements are skipped whent he corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTPACKSTORELO_EPI64,
        ///<summary>Down-converts and stores packed double-precision (64-bit) floating-point elements of v1 into a quadword stream according to conv at a logically mapped starting address mt, storing the low-64-byte elements of that stream (those elements of the stream that map before the first 64-byte-aligned address follwing mt). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTPACKSTORELO_PD,
        ///<summary>Down-converts and stores packed double-precision (64-bit) floating-point elements of v1 into a quadword stream according to conv at a logically mapped starting address mt, storing the low-64-byte elements of that stream (those elements of the stream that map before the first 64-byte-aligned address follwing mt). hint indicates to the processor whether the data is non-temporal. Elements are stored to memory according to element selector k (elements are skipped when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTPACKSTORELO_PD,
        ///<summary>Down-converts and stores packed single-precision (32-bit) floating-point elements of v1 into a byte/word/doubleword stream according to conv at a logically mapped starting address mt, storing the low-64-byte elements of that stream (those elements of the stream that map before the first 64-byte-aligned address follwing mt). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTPACKSTORELO_PS,
        ///<summary>Down-converts and stores packed single-precision (32-bit) floating-point elements of v1 into a byte/word/doubleword stream according to conv at a logically mapped starting address mt, storing the low-64-byte elements of that stream (those elements of the stream that map before the first 64-byte-aligned address follwing mt). hint indicates to the processor whether the data is non-temporal. Elements are stored to memory according to element selector k (elements are skipped when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_EXTPACKSTORELO_PS,
        ///<summary>Extract a 16-bit integer from a, selected with imm8, and store the result in the lower element of dst. (SSE2)</summary>
        _MM_EXTRACT_EPI16,
        ///<summary>Extract a 16-bit integer from a, selected with index, and store the result in dst. (AVX)</summary>
        _MM256_EXTRACT_EPI16,
        ///<summary>Extract a 32-bit integer from a, selected with imm8, and store the result in dst. (SSE4.1)</summary>
        _MM_EXTRACT_EPI32,
        ///<summary>Extract a 32-bit integer from a, selected with index, and store the result in dst. (AVX)</summary>
        _MM256_EXTRACT_EPI32,
        ///<summary>Extract a 64-bit integer from a, selected with imm8, and store the result in dst. (SSE4.1)</summary>
        _MM_EXTRACT_EPI64,
        ///<summary>Extract a 64-bit integer from a, selected with index, and store the result in dst. (AVX)</summary>
        _MM256_EXTRACT_EPI64,
        ///<summary>Extract an 8-bit integer from a, selected with imm8, and store the result in the lower element of dst. (SSE4.1)</summary>
        _MM_EXTRACT_EPI8,
        ///<summary>Extract an 8-bit integer from a, selected with index, and store the result in dst. (AVX)</summary>
        _MM256_EXTRACT_EPI8,
        ///<summary>Extract a 16-bit integer from a, selected with imm8, and store the result in the lower element of dst. (SSE)</summary>
        _MM_EXTRACT_PI16,
        ///<summary>Extract a single-precision (32-bit) floating-point element from a, selected with imm8, and store the result in dst. (SSE4.1)</summary>
        _MM_EXTRACT_PS,
        ///<summary>Extract 128 bits (composed of 2 packed double-precision (64-bit) floating-point elements) from a, selected with imm8, and store the result in dst. (AVX)</summary>
        _MM256_EXTRACTF128_PD,
        ///<summary>Extract 128 bits (composed of 4 packed single-precision (32-bit) floating-point elements) from a, selected with imm8, and store the result in dst. (AVX)</summary>
        _MM256_EXTRACTF128_PS,
        ///<summary>Extract 128 bits (composed of integer data) from a, selected with imm8, and store the result in dst. (AVX)</summary>
        _MM256_EXTRACTF128_SI256,
        ///<summary>Extract 128 bits (composed of 4 packed single-precision (32-bit) floating-point elements) from a, selected with imm8, and store the result in dst. (AVX512VL, AVX512F)</summary>
        _MM256_EXTRACTF32X4_PS,
        ///<summary>Extract 128 bits (composed of 4 packed single-precision (32-bit) floating-point elements) from a, selected with imm8, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_EXTRACTF32X4_PS,
        ///<summary>Extract 128 bits (composed of 4 packed single-precision (32-bit) floating-point elements) from a, selected with imm8, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_EXTRACTF32X4_PS,
        ///<summary>Extract 128 bits (composed of 4 packed single-precision (32-bit) floating-point elements) from a, selected with imm8, and store the result in dst. (AVX512F)</summary>
        _MM512_EXTRACTF32X4_PS,
        ///<summary>Extract 128 bits (composed of 4 packed single-precision (32-bit) floating-point elements) from a, selected with imm8, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXTRACTF32X4_PS,
        ///<summary>Extract 128 bits (composed of 4 packed single-precision (32-bit) floating-point elements) from a, selected with imm8, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_EXTRACTF32X4_PS,
        ///<summary>Extract 256 bits (composed of 8 packed single-precision (32-bit) floating-point elements) from a, selected with imm8, and store the result in dst. (AVX512DQ)</summary>
        _MM512_EXTRACTF32X8_PS,
        ///<summary>Extract 256 bits (composed of 8 packed single-precision (32-bit) floating-point elements) from a, selected with imm8, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_EXTRACTF32X8_PS,
        ///<summary>Extract 256 bits (composed of 8 packed single-precision (32-bit) floating-point elements) from a, selected with imm8, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_EXTRACTF32X8_PS,
        ///<summary>Extract 128 bits (composed of 2 packed double-precision (64-bit) floating-point elements) from a, selected with imm8, and store the result in dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_EXTRACTF64X2_PD,
        ///<summary>Extract 128 bits (composed of 2 packed double-precision (64-bit) floating-point elements) from a, selected with imm8, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_EXTRACTF64X2_PD,
        ///<summary>Extract 128 bits (composed of 2 packed double-precision (64-bit) floating-point elements) from a, selected with imm8, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_EXTRACTF64X2_PD,
        ///<summary>Extract 128 bits (composed of 2 packed double-precision (64-bit) floating-point elements) from a, selected with imm8, and store the result in dst. (AVX512DQ)</summary>
        _MM512_EXTRACTF64X2_PD,
        ///<summary>Extract 128 bits (composed of 2 packed double-precision (64-bit) floating-point elements) from a, selected with imm8, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_EXTRACTF64X2_PD,
        ///<summary>Extract 128 bits (composed of 2 packed double-precision (64-bit) floating-point elements) from a, selected with imm8, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_EXTRACTF64X2_PD,
        ///<summary>Extract 256 bits (composed of 4 packed double-precision (64-bit) floating-point elements) from a, selected with imm8, and store the result in dst. (AVX512F)</summary>
        _MM512_EXTRACTF64X4_PD,
        ///<summary>Extract 256 bits (composed of 4 packed double-precision (64-bit) floating-point elements) from a, selected with imm8, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXTRACTF64X4_PD,
        ///<summary>Extract 256 bits (composed of 4 packed double-precision (64-bit) floating-point elements) from a, selected with imm8, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_EXTRACTF64X4_PD,
        ///<summary>Extract 128 bits (composed of integer data) from a, selected with imm8, and store the result in dst. (AVX2)</summary>
        _MM256_EXTRACTI128_SI256,
        ///<summary>Extract 128 bits (composed of 4 packed 32-bit integers) from a, selected with imm8, and store the result in dst. (AVX512VL, AVX512F)</summary>
        _MM256_EXTRACTI32X4_EPI32,
        ///<summary>Extract 128 bits (composed of 4 packed 32-bit integers) from a, selected with imm8, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_EXTRACTI32X4_EPI32,
        ///<summary>Extract 128 bits (composed of 4 packed 32-bit integers) from a, selected with imm8, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_EXTRACTI32X4_EPI32,
        ///<summary>Extract 128 bits (composed of 4 packed 32-bit integers) from a, selected with imm8, and store the result in dst. (AVX512F)</summary>
        _MM512_EXTRACTI32X4_EPI32,
        ///<summary>Extract 128 bits (composed of 4 packed 32-bit integers) from a, selected with imm8, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXTRACTI32X4_EPI32,
        ///<summary>Extract 128 bits (composed of 4 packed 32-bit integers) from a, selected with imm8, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_EXTRACTI32X4_EPI32,
        ///<summary>Extract 256 bits (composed of 8 packed 32-bit integers) from a, selected with imm8, and store the result in dst. (AVX512DQ)</summary>
        _MM512_EXTRACTI32X8_EPI32,
        ///<summary>Extract 256 bits (composed of 8 packed 32-bit integers) from a, selected with imm8, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_EXTRACTI32X8_EPI32,
        ///<summary>Extract 256 bits (composed of 8 packed 32-bit integers) from a, selected with imm8, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_EXTRACTI32X8_EPI32,
        ///<summary>Extract 128 bits (composed of 2 packed 64-bit integers) from a, selected with imm8, and store the result in dst. (AVX512VL, AVX512DQ)</summary>
        _MM256_EXTRACTI64X2_EPI64,
        ///<summary>Extract 128 bits (composed of 2 packed 64-bit integers) from a, selected with imm8, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_EXTRACTI64X2_EPI64,
        ///<summary>Extract 128 bits (composed of 2 packed 64-bit integers) from a, selected with imm8, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512DQ)</summary>
        _MM256_MASKZ_EXTRACTI64X2_EPI64,
        ///<summary>Extract 128 bits (composed of 2 packed 64-bit integers) from a, selected with imm8, and store the result in dst. (AVX512DQ)</summary>
        _MM512_EXTRACTI64X2_EPI64,
        ///<summary>Extract 128 bits (composed of 2 packed 64-bit integers) from a, selected with imm8, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASK_EXTRACTI64X2_EPI64,
        ///<summary>Extract 128 bits (composed of 2 packed 64-bit integers) from a, selected with imm8, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512DQ)</summary>
        _MM512_MASKZ_EXTRACTI64X2_EPI64,
        ///<summary>Extract 256 bits (composed of 4 packed 64-bit integers) from a, selected with imm8, and store the result in dst. (AVX512F)</summary>
        _MM512_EXTRACTI64X4_EPI64,
        ///<summary>Extract 256 bits (composed of 4 packed 64-bit integers) from a, selected with imm8, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_EXTRACTI64X4_EPI64,
        ///<summary>Extract 256 bits (composed of 4 packed 64-bit integers) from a, selected with imm8, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_EXTRACTI64X4_EPI64,
        ///<summary>Downconverts packed 32-bit integer elements stored in v to a smaller type depending on conv and stores them in memory location mt. hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTSTORE_EPI32,
        ///<summary>Downconverts packed 32-bit integer elements stored in v to a smaller type depending on conv and stores them in memory location mt (elements in mt are unaltered when the corresponding mask bit is not set). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_MASK_EXTSTORE_EPI32,
        ///<summary>Downconverts packed 64-bit integer elements stored in v to a smaller type depending on conv and stores them in memory location mt. hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTSTORE_EPI64,
        ///<summary>Downconverts packed 64-bit integer elements stored in v to a smaller type depending on conv and stores them in memory location mt (elements in mt are unaltered when the corresponding mask bit is not set). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_MASK_EXTSTORE_EPI64,
        ///<summary>Downconverts packed double-precision (64-bit) floating-point elements stored in v to a smaller type depending on conv and stores them in memory location mt. hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTSTORE_PD,
        ///<summary>Downconverts packed double-precision (64-bit) floating-point elements stored in v to a smaller type depending on conv and stores them in memory location mt (elements in mt are unaltered when the corresponding mask bit is not set). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_MASK_EXTSTORE_PD,
        ///<summary>Downconverts packed single-precision (32-bit) floating-point elements stored in v to a smaller type depending on conv and stores them in memory location mt. hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_EXTSTORE_PS,
        ///<summary>Downconverts packed single-precision (32-bit) floating-point elements stored in v to a smaller type depending on conv and stores them in memory location mt using writemask k (elements are not written to memory when the corresponding mask bit is not set). hint indicates to the processor whether the data is non-temporal. (KNCNI)</summary>
        _MM512_MASK_EXTSTORE_PS,
        ///<summary>Fix up packed double-precision (64-bit) floating-point elements in a and b using packed 64-bit integers in c, and store the results in dst. imm8 is used to set the required flags reporting. (AVX512VL, AVX512F)</summary>
        _MM_FIXUPIMM_PD,
        ///<summary>Fix up packed double-precision (64-bit) floating-point elements in a and b using packed 64-bit integers in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. (AVX512VL, AVX512F)</summary>
        _MM_MASK_FIXUPIMM_PD,
        ///<summary>Fix up packed double-precision (64-bit) floating-point elements in a and b using packed 64-bit integers in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_FIXUPIMM_PD,
        ///<summary>Fix up packed double-precision (64-bit) floating-point elements in a and b using packed 64-bit integers in c, and store the results in dst. imm8 is used to set the required flags reporting. (AVX512VL, AVX512F)</summary>
        _MM256_FIXUPIMM_PD,
        ///<summary>Fix up packed double-precision (64-bit) floating-point elements in a and b using packed 64-bit integers in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_FIXUPIMM_PD,
        ///<summary>Fix up packed double-precision (64-bit) floating-point elements in a and b using packed 64-bit integers in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_FIXUPIMM_PD,
        ///<summary>Fix up packed double-precision (64-bit) floating-point elements in a and b using packed 64-bit integers in c, and store the results in dst. imm8 is used to set the required flags reporting. (AVX512F)</summary>
        _MM512_FIXUPIMM_PD,
        ///<summary>Fix up packed double-precision (64-bit) floating-point elements in a and b using packed 64-bit integers in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. (AVX512F)</summary>
        _MM512_MASK_FIXUPIMM_PD,
        ///<summary>Fix up packed double-precision (64-bit) floating-point elements in a and b using packed 64-bit integers in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. (AVX512F)</summary>
        _MM512_MASKZ_FIXUPIMM_PD,
        ///<summary>Fix up packed single-precision (32-bit) floating-point elements in a and b using packed 32-bit integers in c, and store the results in dst. imm8 is used to set the required flags reporting. (AVX512VL, AVX512F)</summary>
        _MM_FIXUPIMM_PS,
        ///<summary>Fix up packed single-precision (32-bit) floating-point elements in a and b using packed 32-bit integers in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. (AVX512VL, AVX512F)</summary>
        _MM_MASK_FIXUPIMM_PS,
        ///<summary>Fix up packed single-precision (32-bit) floating-point elements in a and b using packed 32-bit integers in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_FIXUPIMM_PS,
        ///<summary>Fix up packed single-precision (32-bit) floating-point elements in a and b using packed 32-bit integers in c, and store the results in dst. imm8 is used to set the required flags reporting. (AVX512VL, AVX512F)</summary>
        _MM256_FIXUPIMM_PS,
        ///<summary>Fix up packed single-precision (32-bit) floating-point elements in a and b using packed 32-bit integers in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_FIXUPIMM_PS,
        ///<summary>Fix up packed single-precision (32-bit) floating-point elements in a and b using packed 32-bit integers in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_FIXUPIMM_PS,
        ///<summary>Fix up packed single-precision (32-bit) floating-point elements in a and b using packed 32-bit integers in c, and store the results in dst. imm8 is used to set the required flags reporting. (AVX512F)</summary>
        _MM512_FIXUPIMM_PS,
        ///<summary>Fix up packed single-precision (32-bit) floating-point elements in a and b using packed 32-bit integers in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. (AVX512F)</summary>
        _MM512_MASK_FIXUPIMM_PS,
        ///<summary>Fix up packed single-precision (32-bit) floating-point elements in a and b using packed 32-bit integers in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. (AVX512F)</summary>
        _MM512_MASKZ_FIXUPIMM_PS,
        ///<summary>Fix up packed double-precision (64-bit) floating-point elements in a and b using packed 64-bit integers in c, and store the results in dst. imm8 is used to set the required flags reporting. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_FIXUPIMM_ROUND_PD,
        ///<summary>Fix up packed double-precision (64-bit) floating-point elements in a and b using packed 64-bit integers in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_FIXUPIMM_ROUND_PD,
        ///<summary>Fix up packed double-precision (64-bit) floating-point elements in a and b using packed 64-bit integers in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_FIXUPIMM_ROUND_PD,
        ///<summary>Fix up packed single-precision (32-bit) floating-point elements in a and b using packed 32-bit integers in c, and store the results in dst. imm8 is used to set the required flags reporting. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_FIXUPIMM_ROUND_PS,
        ///<summary>Fix up packed single-precision (32-bit) floating-point elements in a and b using packed 32-bit integers in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_FIXUPIMM_ROUND_PS,
        ///<summary>Fix up packed single-precision (32-bit) floating-point elements in a and b using packed 32-bit integers in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). imm8 is used to set the required flags reporting. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_FIXUPIMM_ROUND_PS,
        ///<summary>Fix up the lower double-precision (64-bit) floating-point elements in a and b using the lower 64-bit integer in c, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. imm8 is used to set the required flags reporting. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_FIXUPIMM_ROUND_SD,
        ///<summary>Fix up the lower double-precision (64-bit) floating-point elements in a and b using the lower 64-bit integer in c, store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. imm8 is used to set the required flags reporting. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_FIXUPIMM_ROUND_SD,
        ///<summary>Fix up the lower double-precision (64-bit) floating-point elements in a and b using the lower 64-bit integer in c, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. imm8 is used to set the required flags reporting. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_FIXUPIMM_ROUND_SD,
        ///<summary>Fix up the lower single-precision (32-bit) floating-point elements in a and b using the lower 32-bit integer in c, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. imm8 is used to set the required flags reporting. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_FIXUPIMM_ROUND_SS,
        ///<summary>Fix up the lower single-precision (32-bit) floating-point elements in a and b using the lower 32-bit integer in c, store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. imm8 is used to set the required flags reporting. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_FIXUPIMM_ROUND_SS,
        ///<summary>Fix up the lower single-precision (32-bit) floating-point elements in a and b using the lower 32-bit integer in c, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. imm8 is used to set the required flags reporting. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_FIXUPIMM_ROUND_SS,
        ///<summary>Fix up the lower double-precision (64-bit) floating-point elements in a and b using the lower 64-bit integer in c, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. imm8 is used to set the required flags reporting. (AVX512F)</summary>
        _MM_FIXUPIMM_SD,
        ///<summary>Fix up the lower double-precision (64-bit) floating-point elements in a and b using the lower 64-bit integer in c, store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. imm8 is used to set the required flags reporting. (AVX512F)</summary>
        _MM_MASK_FIXUPIMM_SD,
        ///<summary>Fix up the lower double-precision (64-bit) floating-point elements in a and b using the lower 64-bit integer in c, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. imm8 is used to set the required flags reporting. (AVX512F)</summary>
        _MM_MASKZ_FIXUPIMM_SD,
        ///<summary>Fix up the lower single-precision (32-bit) floating-point elements in a and b using the lower 32-bit integer in c, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. imm8 is used to set the required flags reporting. (AVX512F)</summary>
        _MM_FIXUPIMM_SS,
        ///<summary>Fix up the lower single-precision (32-bit) floating-point elements in a and b using the lower 32-bit integer in c, store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. imm8 is used to set the required flags reporting. (AVX512F)</summary>
        _MM_MASK_FIXUPIMM_SS,
        ///<summary>Fix up the lower single-precision (32-bit) floating-point elements in a and b using the lower 32-bit integer in c, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. imm8 is used to set the required flags reporting. (AVX512F)</summary>
        _MM_MASKZ_FIXUPIMM_SS,
        ///<summary>Fixes up NaN's from packed double-precision (64-bit) floating-point elements in v1 and v2, storing the results in dst and storing the quietized NaN's from v1 in v3. (KNCNI)</summary>
        _MM512_FIXUPNAN_PD,
        ///<summary>Fixes up NaN's from packed double-precision (64-bit) floating-point elements in v1 and v2, storing the results in dst using writemask k (only elements whose corresponding mask bit is set are used in the computation). Quietized NaN's from v1 are stored in v3. (KNCNI)</summary>
        _MM512_MASK_FIXUPNAN_PD,
        ///<summary>Fixes up NaN's from packed single-precision (32-bit) floating-point elements in v1 and v2, storing the results in dst and storing the quietized NaN's from v1 in v3. (KNCNI)</summary>
        _MM512_FIXUPNAN_PS,
        ///<summary>Fixes up NaN's from packed single-precision (32-bit) floating-point elements in v1 and v2, storing the results in dst using writemask k (only elements whose corresponding mask bit is set are used in the computation). Quietized NaN's from v1 are stored in v3. (KNCNI)</summary>
        _MM512_MASK_FIXUPNAN_PS,
        ///<summary>Round the packed double-precision (64-bit) floating-point elements in a down to an integer value, and store the results as packed double-precision floating-point elements in dst. (SSE4.1)</summary>
        _MM_FLOOR_PD,
        ///<summary>Round the packed double-precision (64-bit) floating-point elements in a down to an integer value, and store the results as packed double-precision floating-point elements in dst. (AVX)</summary>
        _MM256_FLOOR_PD,
        ///<summary>Round the packed double-precision (64-bit) floating-point elements in a down to an integer value, and store the results as packed double-precision floating-point elements in dst. (AVX512F)</summary>
        _MM512_FLOOR_PD,
        ///<summary>Round the packed double-precision (64-bit) floating-point elements in a down to an integer value, and store the results as packed double-precision floating-point elements in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_FLOOR_PD,
        ///<summary>Round the packed single-precision (32-bit) floating-point elements in a down to an integer value, and store the results as packed single-precision floating-point elements in dst. (SSE4.1)</summary>
        _MM_FLOOR_PS,
        ///<summary>Round the packed single-precision (32-bit) floating-point elements in a down to an integer value, and store the results as packed single-precision floating-point elements in dst. (AVX)</summary>
        _MM256_FLOOR_PS,
        ///<summary>Round the packed single-precision (32-bit) floating-point elements in a down to an integer value, and store the results as packed single-precision floating-point elements in dst. (AVX512F)</summary>
        _MM512_FLOOR_PS,
        ///<summary>Round the packed single-precision (32-bit) floating-point elements in a down to an integer value, and store the results as packed single-precision floating-point elements in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_FLOOR_PS,
        ///<summary>Round the lower double-precision (64-bit) floating-point element in b down to an integer value, store the result as a double-precision floating-point element in the lower element of dst, and copy the upper element from a to the upper element of dst. (SSE4.1)</summary>
        _MM_FLOOR_SD,
        ///<summary>Round the lower single-precision (32-bit) floating-point element in b down to an integer value, store the result as a single-precision floating-point element in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (SSE4.1)</summary>
        _MM_FLOOR_SS,
        ///<summary>Multiply packed 32-bit integer elements in a and b, add the intermediate result to packed elements in c and store the results in dst. (KNCNI)</summary>
        _MM512_FMADD_EPI32,
        ///<summary>Multiply packed 32-bit integer elements in a and b, add the intermediate result to packed elements in c and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_FMADD_EPI32,
        ///<summary>Multiply packed 32-bit integer elements in a and b, add the intermediate result to packed elements in c and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK3_FMADD_EPI32,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst. (FMA)</summary>
        _MM_FMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_FMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK3_FMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_FMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst. (FMA)</summary>
        _MM256_FMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_FMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK3_FMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_FMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_FMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_FMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_FMADD_PD,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst. (FMA)</summary>
        _MM_FMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_FMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK3_FMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_FMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst. (FMA)</summary>
        _MM256_FMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_FMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK3_FMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_FMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_FMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_FMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_FMADD_PS,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_FMADD_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK_FMADD_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FMADD_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_FMADD_ROUND_PD,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_FMADD_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK_FMADD_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FMADD_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the intermediate result to packed elements in c, and store the results in a using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_FMADD_ROUND_PS,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and add the intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_FMADD_ROUND_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and add the intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK3_FMADD_ROUND_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and add the intermediate result to the lower element in c. Store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_FMADD_ROUND_SD,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and add the intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_FMADD_ROUND_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and add the intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK3_FMADD_ROUND_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and add the intermediate result to the lower element in c. Store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_FMADD_ROUND_SS,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and add the intermediate result to the lower element in c. Store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (FMA)</summary>
        _MM_FMADD_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and add the intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASK_FMADD_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and add the intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASK3_FMADD_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and add the intermediate result to the lower element in c. Store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASKZ_FMADD_SD,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and add the intermediate result to the lower element in c. Store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (FMA)</summary>
        _MM_FMADD_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and add the intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASK_FMADD_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and add the intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASK3_FMADD_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and add the intermediate result to the lower element in c. Store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASKZ_FMADD_SS,
        ///<summary>Multiply packed 32-bit integer elements in each 4-element set of a and by element 1 of the corresponding 4-element set from b, add the intermediate result to element 0 of the corresponding 4-element set from b, and store the results in dst. (KNCNI)</summary>
        _MM512_FMADD233_EPI32,
        ///<summary>Multiply packed 32-bit integer elements in each 4-element set of a and by element 1 of the corresponding 4-element set from b, add the intermediate result to element 0 of the corresponding 4-element set from b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_FMADD233_EPI32,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in each 4-element set of a and by element 1 of the corresponding 4-element set from b, add the intermediate result to element 0 of the corresponding 4-element set from b, and store the results in dst. (KNCNI)</summary>
        _MM512_FMADD233_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in each 4-element set of a and by element 1 of the corresponding 4-element set from b, add the intermediate result to element 0 of the corresponding 4-element set from b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_FMADD233_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in each 4-element set of a and by element 1 of the corresponding 4-element set from b, add the intermediate result to element 0 of the corresponding 4-element set from b, and store the results in dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_FMADD233_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in each 4-element set of a and by element 1 of the corresponding 4-element set from b, add the intermediate result to element 0 of the corresponding 4-element set from b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (KNCNI)</summary>
        _MM512_MASK_FMADD233_ROUND_PS,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst. (FMA)</summary>
        _MM_FMADDSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_FMADDSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK3_FMADDSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_FMADDSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst. (FMA)</summary>
        _MM256_FMADDSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_FMADDSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK3_FMADDSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_FMADDSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst. (AVX512F)</summary>
        _MM512_FMADDSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_FMADDSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK3_FMADDSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_FMADDSUB_PD,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst. (FMA)</summary>
        _MM_FMADDSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_FMADDSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK3_FMADDSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_FMADDSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst. (FMA)</summary>
        _MM256_FMADDSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_FMADDSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK3_FMADDSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_FMADDSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst. (AVX512F)</summary>
        _MM512_FMADDSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_FMADDSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK3_FMADDSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_FMADDSUB_PS,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_FMADDSUB_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_FMADDSUB_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set).  Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK3_FMADDSUB_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_FMADDSUB_ROUND_PD,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_FMADDSUB_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_FMADDSUB_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set).  Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK3_FMADDSUB_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively add and subtract packed elements in c to/from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_FMADDSUB_ROUND_PS,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst. (FMA)</summary>
        _MM_FMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_FMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK3_FMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_FMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst. (FMA)</summary>
        _MM256_FMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_FMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK3_FMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_FMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_FMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_FMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_FMSUB_PD,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst. (FMA)</summary>
        _MM_FMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_FMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK3_FMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_FMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst. (FMA)</summary>
        _MM256_FMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_FMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK3_FMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_FMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_FMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_FMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_FMSUB_PS,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_FMSUB_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK_FMSUB_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set).  Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FMSUB_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_FMSUB_ROUND_PD,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_FMSUB_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK_FMSUB_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set).  Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FMSUB_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_FMSUB_ROUND_PS,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and subtract the lower element in c from the intermediate result. Store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_FMSUB_ROUND_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and subtract the lower element in c from the intermediate result. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK3_FMSUB_ROUND_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and subtract the lower element in c from the intermediate result. Store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_FMSUB_ROUND_SD,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and subtract the lower element in c from the intermediate result. Store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_FMSUB_ROUND_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and subtract the lower element in c from the intermediate result. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK3_FMSUB_ROUND_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and subtract the lower element in c from the intermediate result. Store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_FMSUB_ROUND_SS,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and subtract the lower element in c from the intermediate result. Store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (FMA)</summary>
        _MM_FMSUB_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and subtract the lower element in c from the intermediate result. Store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASK_FMSUB_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and subtract the lower element in c from the intermediate result. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASK3_FMSUB_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and subtract the lower element in c from the intermediate result. Store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASKZ_FMSUB_SD,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and subtract the lower element in c from the intermediate result. Store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (FMA)</summary>
        _MM_FMSUB_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and subtract the lower element in c from the intermediate result. Store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASK_FMSUB_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and subtract the lower element in c from the intermediate result. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASK3_FMSUB_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and subtract the lower element in c from the intermediate result. Store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASKZ_FMSUB_SS,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst. (FMA)</summary>
        _MM_FMSUBADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_FMSUBADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK3_FMSUBADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_FMSUBADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst. (FMA)</summary>
        _MM256_FMSUBADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_FMSUBADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK3_FMSUBADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_FMSUBADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst. (AVX512F)</summary>
        _MM512_FMSUBADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_FMSUBADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK3_FMSUBADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_FMSUBADD_PD,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst. (FMA)</summary>
        _MM_FMSUBADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_FMSUBADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK3_FMSUBADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_FMSUBADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst. (FMA)</summary>
        _MM256_FMSUBADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_FMSUBADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK3_FMSUBADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_FMSUBADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst. (AVX512F)</summary>
        _MM512_FMSUBADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_FMSUBADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK3_FMSUBADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_FMSUBADD_PS,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_FMSUBADD_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_FMSUBADD_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set).  Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK3_FMSUBADD_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_FMSUBADD_ROUND_PD,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_FMSUBADD_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK_FMSUBADD_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set).  Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASK3_FMSUBADD_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, alternatively subtract and add packed elements in c from/to the intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_FMSUBADD_ROUND_PS,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst. (FMA)</summary>
        _MM_FNMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_FNMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK3_FNMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_FNMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst. (FMA)</summary>
        _MM256_FNMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_FNMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK3_FNMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_FNMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_FNMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_FNMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FNMADD_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_FNMADD_PD,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst. (FMA)</summary>
        _MM_FNMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_FNMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK3_FNMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_FNMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst. (FMA)</summary>
        _MM256_FNMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_FNMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK3_FNMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_FNMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_FNMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_FNMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FNMADD_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_FNMADD_PS,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst. 	 Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_FNMADD_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK_FNMADD_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set).  Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FNMADD_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_FNMADD_ROUND_PD,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst.   	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_FNMADD_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK_FNMADD_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set).  Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FNMADD_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, add the negated intermediate result to packed elements in c, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_FNMADD_ROUND_PS,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and add the negated intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_FNMADD_ROUND_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and add the negated intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK3_FNMADD_ROUND_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and add the negated intermediate result to the lower element in c. Store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_FNMADD_ROUND_SD,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and add the negated intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_FNMADD_ROUND_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and add the negated intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK3_FNMADD_ROUND_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and add the negated intermediate result to the lower element in c. Store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_FNMADD_ROUND_SS,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and add the negated intermediate result to the lower element in c. Store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (FMA)</summary>
        _MM_FNMADD_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and add the negated intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASK_FNMADD_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and add the negated intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASK3_FNMADD_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and add the negated intermediate result to the lower element in c. Store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASKZ_FNMADD_SD,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and add the negated intermediate result to the lower element in c. Store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (FMA)</summary>
        _MM_FNMADD_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and add the negated intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from a when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASK_FNMADD_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and add the negated intermediate result to the lower element in c. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASK3_FNMADD_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and add the negated intermediate result to the lower element in c. Store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASKZ_FNMADD_SS,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst. (FMA)</summary>
        _MM_FNMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_FNMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK3_FNMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_FNMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst. (FMA)</summary>
        _MM256_FNMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_FNMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK3_FNMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_FNMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_FNMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_FNMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FNMSUB_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_FNMSUB_PD,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst. (FMA)</summary>
        _MM_FNMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK_FNMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASK3_FNMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_FNMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst. (FMA)</summary>
        _MM256_FNMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK_FNMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASK3_FNMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_FNMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst. (AVX512F, KNCNI)</summary>
        _MM512_FNMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_FNMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FNMSUB_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASKZ_FNMSUB_PS,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst.   	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_FNMSUB_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set). 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK_FNMSUB_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set). Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FNMSUB_ROUND_PD,
        ///<summary>Multiply packed double-precision (64-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_FNMSUB_ROUND_PD,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst.  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_FNMSUB_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from a when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK_FNMSUB_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using writemask k (elements are copied from c when the corresponding mask bit is not set).  Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK3_FNMSUB_ROUND_PS,
        ///<summary>Multiply packed single-precision (32-bit) floating-point elements in a and b, subtract packed elements in c from the negated intermediate result, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_FNMSUB_ROUND_PS,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and subtract the lower element in c from the negated intermediate result. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_FNMSUB_ROUND_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and subtract the lower element in c from the negated intermediate result. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK3_FNMSUB_ROUND_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and subtract the lower element in c from the negated intermediate result. Store the result in dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_FNMSUB_ROUND_SD,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and subtract the lower element in c from the negated intermediate result. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_FNMSUB_ROUND_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, subtract the lower element in c from the negated intermediate result, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst using writemask k (elements are copied from c when the corresponding mask bit is not set).  	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK3_FNMSUB_ROUND_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and subtract the lower element in c from the negated intermediate result. Store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_FNMSUB_ROUND_SS,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and subtract the lower element in c from the negated intermediate result. Store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. (FMA)</summary>
        _MM_FNMSUB_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and subtract the lower element in c from the negated intermediate result. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASK_FNMSUB_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and subtract the lower element in c from the negated intermediate result. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASK3_FNMSUB_SD,
        ///<summary>Multiply the lower double-precision (64-bit) floating-point elements in a and b, and subtract the lower element in c from the negated intermediate result. Store the result in dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. (AVX512F)</summary>
        _MM_MASKZ_FNMSUB_SD,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and subtract the lower element in c from the negated intermediate result. Store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. (FMA)</summary>
        _MM_FNMSUB_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and subtract the lower element in c from the negated intermediate result. Store the result in the lower element of dst using writemask k (the element is copied from c when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASK_FNMSUB_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and subtract the lower element in c from the negated intermediate result. Store the result in the lower element of dst, and copy the upper element from a to the upper element of dst using writemask k (elements are copied from c when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM_MASK3_FNMSUB_SS,
        ///<summary>Multiply the lower single-precision (32-bit) floating-point elements in a and b, and subtract the lower element in c from the negated intermediate result. Store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. (AVX512F)</summary>
        _MM_MASKZ_FNMSUB_SS,
        ///<summary>Test packed double-precision (64-bit) floating-point elements in a for special categories specified by imm8, and store the results in mask vector k. 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512VL, AVX512DQ)</summary>
        _MM_FPCLASS_PD_MASK,
        ///<summary>Test packed double-precision (64-bit) floating-point elements in a for special categories specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_FPCLASS_PD_MASK,
        ///<summary>Test packed double-precision (64-bit) floating-point elements in a for special categories specified by imm8, and store the results in mask vector k. 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512VL, AVX512DQ)</summary>
        _MM256_FPCLASS_PD_MASK,
        ///<summary>Test packed double-precision (64-bit) floating-point elements in a for special categories specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_FPCLASS_PD_MASK,
        ///<summary>Test packed double-precision (64-bit) floating-point elements in a for special categories specified by imm8, and store the results in mask vector k. 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512DQ)</summary>
        _MM512_FPCLASS_PD_MASK,
        ///<summary>Test packed double-precision (64-bit) floating-point elements in a for special categories specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512DQ)</summary>
        _MM512_MASK_FPCLASS_PD_MASK,
        ///<summary>Test packed single-precision (32-bit) floating-point elements in a for special categories specified by imm8, and store the results in mask vector k. 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512VL, AVX512DQ)</summary>
        _MM_FPCLASS_PS_MASK,
        ///<summary>Test packed single-precision (32-bit) floating-point elements in a for special categories specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512VL, AVX512DQ)</summary>
        _MM_MASK_FPCLASS_PS_MASK,
        ///<summary>Test packed single-precision (32-bit) floating-point elements in a for special categories specified by imm8, and store the results in mask vector k. 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512VL, AVX512DQ)</summary>
        _MM256_FPCLASS_PS_MASK,
        ///<summary>Test packed single-precision (32-bit) floating-point elements in a for special categories specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512VL, AVX512DQ)</summary>
        _MM256_MASK_FPCLASS_PS_MASK,
        ///<summary>Test packed single-precision (32-bit) floating-point elements in a for special categories specified by imm8, and store the results in mask vector k. 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512DQ)</summary>
        _MM512_FPCLASS_PS_MASK,
        ///<summary>Test packed single-precision (32-bit) floating-point elements in a for special categories specified by imm8, and store the results in mask vector k using zeromask k1 (elements are zeroed out when the corresponding mask bit is not set). 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512DQ)</summary>
        _MM512_MASK_FPCLASS_PS_MASK,
        ///<summary>Test the lower double-precision (64-bit) floating-point element in a for special categories specified by imm8, and store the result in mask vector k. 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512DQ)</summary>
        _MM_FPCLASS_SD_MASK,
        ///<summary>Test the lower double-precision (64-bit) floating-point element in a for special categories specified by imm8, and store the result in mask vector k using zeromask k1 (the element is zeroed out when mask bit 0 is not set). 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512DQ)</summary>
        _MM_MASK_FPCLASS_SD_MASK,
        ///<summary>Test the lower single-precision (32-bit) floating-point element in a for special categories specified by imm8, and store the result in mask vector k. 	imm" can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512DQ)</summary>
        _MM_FPCLASS_SS_MASK,
        ///<summary>Test the lower single-precision (32-bit) floating-point element in a for special categories specified by imm8, and store the result in mask vector k using zeromask k1 (the element is zeroed out when mask bit 0 is not set). 	imm can be a combination of:    0x01 // QNaN     0x02 // Positive Zero     0x04 // Negative Zero     0x08 // Positive Infinity     0x10 // Negative Infinity     0x20 // Denormal     0x40 // Negative     0x80 // SNaN (AVX512DQ)</summary>
        _MM_MASK_FPCLASS_SS_MASK,
        ///<summary>Free aligned memory that was allocated with _mm_malloc. (SSE)</summary>
        _MM_FREE,
        ///<summary>Copy 32-bit integer a to the lower elements of dst, and zero the upper element of dst. (MMX)</summary>
        _M_FROM_INT,
        ///<summary>Copy 64-bit integer a to dst. (MMX)</summary>
        _M_FROM_INT64,
        ///<summary>Reload the x87 FPU, MMX technology, XMM, and MXCSR registers from the 512-byte memory image at mem_addr. This data should have been written to memory previously using the FXSAVE instruction, and in the same format as required by the operating mode. mem_addr must be aligned on a 16-byte boundary. (FXSR)</summary>
        _FXRSTOR,
        ///<summary>Reload the x87 FPU, MMX technology, XMM, and MXCSR registers from the 512-byte memory image at mem_addr. This data should have been written to memory previously using the FXSAVE64 instruction, and in the same format as required by the operating mode. mem_addr must be aligned on a 16-byte boundary. (FXSR)</summary>
        _FXRSTOR64,
        ///<summary>Save the current state of the x87 FPU, MMX technology, XMM, and MXCSR registers to a 512-byte memory location at mem_addr. The clayout of the 512-byte region depends on the operating mode. Bytes [511:464] are available for software use and will not be overwritten by the processor. (FXSR)</summary>
        _FXSAVE,
        ///<summary>Save the current state of the x87 FPU, MMX technology, XMM, and MXCSR registers to a 512-byte memory location at mem_addr. The layout of the 512-byte region depends on the operating mode. Bytes [511:464] are available for software use and will not be overwritten by the processor. (FXSR)</summary>
        _FXSAVE64,
        ///<summary>Macro: Get the exception mask bits from the MXCSR control and status register. The exception mask may contain any of the following flags: _MM_MASK_INVALID, _MM_MASK_DIV_ZERO, _MM_MASK_DENORM, _MM_MASK_OVERFLOW, _MM_MASK_UNDERFLOW, _MM_MASK_INEXACT (SSE)</summary>
        _MM_GET_EXCEPTION_MASK,
        ///<summary>Macro: Get the exception state bits from the MXCSR control and status register. The exception state may contain any of the following flags: _MM_EXCEPT_INVALID, _MM_EXCEPT_DIV_ZERO, _MM_EXCEPT_DENORM, _MM_EXCEPT_OVERFLOW, _MM_EXCEPT_UNDERFLOW, _MM_EXCEPT_INEXACT (SSE)</summary>
        _MM_GET_EXCEPTION_STATE,
        ///<summary>Macro: Get the flush zero bits from the MXCSR control and status register. The flush zero may contain any of the following flags: _MM_FLUSH_ZERO_ON or _MM_FLUSH_ZERO_OFF (SSE)</summary>
        _MM_GET_FLUSH_ZERO_MODE,
        ///<summary>Macro: Get the rounding mode bits from the MXCSR control and status register. The rounding mode may contain any of the following flags: _MM_ROUND_NEAREST, _MM_ROUND_DOWN, _MM_ROUND_UP, _MM_ROUND_TOWARD_ZERO (SSE)</summary>
        _MM_GET_ROUNDING_MODE,
        ///<summary>Get the unsigned 32-bit value of the MXCSR control and status register. (SSE)</summary>
        _MM_GETCSR,
        ///<summary>Convert the exponent of each packed double-precision (64-bit) floating-point element in a to a double-precision (64-bit) floating-point number representing the integer exponent, and store the results in dst. This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512VL, AVX512F)</summary>
        _MM_GETEXP_PD,
        ///<summary>Convert the exponent of each packed double-precision (64-bit) floating-point element in a to a double-precision (64-bit) floating-point number representing the integer exponent, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512VL, AVX512F)</summary>
        _MM_MASK_GETEXP_PD,
        ///<summary>Convert the exponent of each packed double-precision (64-bit) floating-point element in a to a double-precision (64-bit) floating-point number representing the integer exponent, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_GETEXP_PD,
        ///<summary>Convert the exponent of each packed double-precision (64-bit) floating-point element in a to a double-precision (64-bit) floating-point number representing the integer exponent, and store the results in dst. This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512VL, AVX512F)</summary>
        _MM256_GETEXP_PD,
        ///<summary>Convert the exponent of each packed double-precision (64-bit) floating-point element in a to a double-precision (64-bit) floating-point number representing the integer exponent, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_GETEXP_PD,
        ///<summary>Convert the exponent of each packed double-precision (64-bit) floating-point element in a to a double-precision (64-bit) floating-point number representing the integer exponent, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_GETEXP_PD,
        ///<summary>Convert the exponent of each packed double-precision (64-bit) floating-point element in a to a double-precision (64-bit) floating-point number representing the integer exponent, and store the results in dst. This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512F, KNCNI)</summary>
        _MM512_GETEXP_PD,
        ///<summary>Convert the exponent of each packed double-precision (64-bit) floating-point element in a to a double-precision (64-bit) floating-point number representing the integer exponent, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512F, KNCNI)</summary>
        _MM512_MASK_GETEXP_PD,
        ///<summary>Convert the exponent of each packed double-precision (64-bit) floating-point element in a to a double-precision (64-bit) floating-point number representing the integer exponent, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512F)</summary>
        _MM512_MASKZ_GETEXP_PD,
        ///<summary>Convert the exponent of each packed single-precision (32-bit) floating-point element in a to a single-precision (32-bit) floating-point number representing the integer exponent, and store the results in dst. This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512VL, AVX512F)</summary>
        _MM_GETEXP_PS,
        ///<summary>Convert the exponent of each packed single-precision (32-bit) floating-point element in a to a single-precision (32-bit) floating-point number representing the integer exponent, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512VL, AVX512F)</summary>
        _MM_MASK_GETEXP_PS,
        ///<summary>Convert the exponent of each packed single-precision (32-bit) floating-point element in a to a single-precision (32-bit) floating-point number representing the integer exponent, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_GETEXP_PS,
        ///<summary>Convert the exponent of each packed single-precision (32-bit) floating-point element in a to a single-precision (32-bit) floating-point number representing the integer exponent, and store the results in dst. This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512VL, AVX512F)</summary>
        _MM256_GETEXP_PS,
        ///<summary>Convert the exponent of each packed single-precision (32-bit) floating-point element in a to a single-precision (32-bit) floating-point number representing the integer exponent, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_GETEXP_PS,
        ///<summary>Convert the exponent of each packed single-precision (32-bit) floating-point element in a to a single-precision (32-bit) floating-point number representing the integer exponent, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_GETEXP_PS,
        ///<summary>Convert the exponent of each packed single-precision (32-bit) floating-point element in a to a single-precision (32-bit) floating-point number representing the integer exponent, and store the results in dst. This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512F, KNCNI)</summary>
        _MM512_GETEXP_PS,
        ///<summary>Convert the exponent of each packed single-precision (32-bit) floating-point element in a to a single-precision (32-bit) floating-point number representing the integer exponent, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512F, KNCNI)</summary>
        _MM512_MASK_GETEXP_PS,
        ///<summary>Convert the exponent of each packed single-precision (32-bit) floating-point element in a to a single-precision (32-bit) floating-point number representing the integer exponent, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. (AVX512F)</summary>
        _MM512_MASKZ_GETEXP_PS,
        ///<summary>Convert the exponent of each packed double-precision (64-bit) floating-point element in a to a double-precision (64-bit) floating-point number representing the integer exponent, and store the results in dst. This intrinsic essentially calculates floor(log2(x)) for each element. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_GETEXP_ROUND_PD,
        ///<summary>Convert the exponent of each packed double-precision (64-bit) floating-point element in a to a double-precision (64-bit) floating-point number representing the integer exponent, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK_GETEXP_ROUND_PD,
        ///<summary>Convert the exponent of each packed double-precision (64-bit) floating-point element in a to a double-precision (64-bit) floating-point number representing the integer exponent, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_GETEXP_ROUND_PD,
        ///<summary>Convert the exponent of each packed single-precision (32-bit) floating-point element in a to a single-precision (32-bit) floating-point number representing the integer exponent, and store the results in dst. This intrinsic essentially calculates floor(log2(x)) for each element. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_GETEXP_ROUND_PS,
        ///<summary>Convert the exponent of each packed single-precision (32-bit) floating-point element in a to a single-precision (32-bit) floating-point number representing the integer exponent, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK_GETEXP_ROUND_PS,
        ///<summary>Convert the exponent of each packed single-precision (32-bit) floating-point element in a to a single-precision (32-bit) floating-point number representing the integer exponent, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates floor(log2(x)) for each element. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_GETEXP_ROUND_PS,
        ///<summary>Convert the exponent of the lower double-precision (64-bit) floating-point element in b to a double-precision (64-bit) floating-point number representing the integer exponent, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. This intrinsic essentially calculates floor(log2(x)) for the lower element. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_GETEXP_ROUND_SD,
        ///<summary>Convert the exponent of the lower double-precision (64-bit) floating-point element in b to a double-precision (64-bit) floating-point number representing the integer exponent, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. This intrinsic essentially calculates floor(log2(x)) for the lower element. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_GETEXP_ROUND_SD,
        ///<summary>Convert the exponent of the lower double-precision (64-bit) floating-point element in b to a double-precision (64-bit) floating-point number representing the integer exponent, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. This intrinsic essentially calculates floor(log2(x)) for the lower element. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_GETEXP_ROUND_SD,
        ///<summary>Convert the exponent of the lower single-precision (32-bit) floating-point element in b to a single-precision (32-bit) floating-point number representing the integer exponent, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. This intrinsic essentially calculates floor(log2(x)) for the lower element. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_GETEXP_ROUND_SS,
        ///<summary>Convert the exponent of the lower single-precision (32-bit) floating-point element in b to a single-precision (32-bit) floating-point number representing the integer exponent, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. This intrinsic essentially calculates floor(log2(x)) for the lower element. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_GETEXP_ROUND_SS,
        ///<summary>Convert the exponent of the lower single-precision (32-bit) floating-point element in b to a single-precision (32-bit) floating-point number representing the integer exponent, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. This intrinsic essentially calculates floor(log2(x)) for the lower element. 	Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_GETEXP_ROUND_SS,
        ///<summary>Convert the exponent of the lower double-precision (64-bit) floating-point element in b to a double-precision (64-bit) floating-point number representing the integer exponent, store the result in the lower element of dst, and copy the upper element from a to the upper element of dst. This intrinsic essentially calculates floor(log2(x)) for the lower element. (AVX512F)</summary>
        _MM_GETEXP_SD,
        ///<summary>Convert the exponent of the lower double-precision (64-bit) floating-point element in b to a double-precision (64-bit) floating-point number representing the integer exponent, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. This intrinsic essentially calculates floor(log2(x)) for the lower element. (AVX512F)</summary>
        _MM_MASK_GETEXP_SD,
        ///<summary>Convert the exponent of the lower double-precision (64-bit) floating-point element in b to a double-precision (64-bit) floating-point number representing the integer exponent, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from a to the upper element of dst. This intrinsic essentially calculates floor(log2(x)) for the lower element. (AVX512F)</summary>
        _MM_MASKZ_GETEXP_SD,
        ///<summary>Convert the exponent of the lower single-precision (32-bit) floating-point element in b to a single-precision (32-bit) floating-point number representing the integer exponent, store the result in the lower element of dst, and copy the upper 3 packed elements from a to the upper elements of dst. This intrinsic essentially calculates floor(log2(x)) for the lower element. (AVX512F)</summary>
        _MM_GETEXP_SS,
        ///<summary>Convert the exponent of the lower single-precision (32-bit) floating-point element in b to a single-precision (32-bit) floating-point number representing the integer exponent, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. This intrinsic essentially calculates floor(log2(x)) for the lower element. (AVX512F)</summary>
        _MM_MASK_GETEXP_SS,
        ///<summary>Convert the exponent of the lower single-precision (32-bit) floating-point element in b to a single-precision (32-bit) floating-point number representing the integer exponent, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from a to the upper elements of dst. This intrinsic essentially calculates floor(log2(x)) for the lower element. (AVX512F)</summary>
        _MM_MASKZ_GETEXP_SS,
        ///<summary>Normalize the mantissas of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512VL, AVX512F)</summary>
        _MM_GETMANT_PD,
        ///<summary>Normalize the mantissas of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512VL, AVX512F)</summary>
        _MM_MASK_GETMANT_PD,
        ///<summary>Normalize the mantissas of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_GETMANT_PD,
        ///<summary>Normalize the mantissas of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512VL, AVX512F)</summary>
        _MM256_GETMANT_PD,
        ///<summary>Normalize the mantissas of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512VL, AVX512F)</summary>
        _MM256_MASK_GETMANT_PD,
        ///<summary>Normalize the mantissas of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_GETMANT_PD,
        ///<summary>Normalize the mantissas of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512F, KNCNI)</summary>
        _MM512_GETMANT_PD,
        ///<summary>Normalize the mantissas of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512F, KNCNI)</summary>
        _MM512_MASK_GETMANT_PD,
        ///<summary>Normalize the mantissas of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512F)</summary>
        _MM512_MASKZ_GETMANT_PD,
        ///<summary>Normalize the mantissas of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512VL, AVX512F)</summary>
        _MM_GETMANT_PS,
        ///<summary>Normalize the mantissas of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512VL, AVX512F)</summary>
        _MM_MASK_GETMANT_PS,
        ///<summary>Normalize the mantissas of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512VL, AVX512F)</summary>
        _MM_MASKZ_GETMANT_PS,
        ///<summary>Normalize the mantissas of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512VL, AVX512F)</summary>
        _MM256_GETMANT_PS,
        ///<summary>Normalize the mantissas of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512VL, AVX512F)</summary>
        _MM256_MASK_GETMANT_PS,
        ///<summary>Normalize the mantissas of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512VL, AVX512F)</summary>
        _MM256_MASKZ_GETMANT_PS,
        ///<summary>Normalize the mantissas of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512F, KNCNI)</summary>
        _MM512_GETMANT_PS,
        ///<summary>Normalize the mantissas of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512F, KNCNI)</summary>
        _MM512_MASK_GETMANT_PS,
        ///<summary>Normalize the mantissas of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512F)</summary>
        _MM512_MASKZ_GETMANT_PS,
        ///<summary>Normalize the mantissas of packed double-precision (64-bit) floating-point elements in a, and store the results in dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_GETMANT_ROUND_PD,
        ///<summary>Normalize the mantissas of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK_GETMANT_ROUND_PD,
        ///<summary>Normalize the mantissas of packed double-precision (64-bit) floating-point elements in a, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_GETMANT_ROUND_PD,
        ///<summary>Normalize the mantissas of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_GETMANT_ROUND_PS,
        ///<summary>Normalize the mantissas of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F, KNCNI)</summary>
        _MM512_MASK_GETMANT_ROUND_PS,
        ///<summary>Normalize the mantissas of packed single-precision (32-bit) floating-point elements in a, and store the results in dst using zeromask k (elements are zeroed out when the corresponding mask bit is not set). This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM512_MASKZ_GETMANT_ROUND_PS,
        ///<summary>Normalize the mantissas of the lower double-precision (64-bit) floating-point element in a, store the result in the lower element of dst, and copy the upper element from b to the upper element of dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_GETMANT_ROUND_SD,
        ///<summary>Normalize the mantissas of the lower double-precision (64-bit) floating-point element in a, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper element from b to the upper element of dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_GETMANT_ROUND_SD,
        ///<summary>Normalize the mantissas of the lower double-precision (64-bit) floating-point element in a, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from b to the upper element of dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_GETMANT_ROUND_SD,
        ///<summary>Normalize the mantissas of the lower single-precision (32-bit) floating-point element in a, store the result in the lower element of dst, and copy the upper 3 packed elements from b to the upper elements of dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_GETMANT_ROUND_SS,
        ///<summary>Normalize the mantissas of the lower single-precision (32-bit) floating-point element in a, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper 3 packed elements from b to the upper elements of dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASK_GETMANT_ROUND_SS,
        ///<summary>Normalize the mantissas of the lower single-precision (32-bit) floating-point element in a, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from b to the upper elements of dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1Rounding is done according to the rounding parameter, which can be one of:    (_MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC) // round to nearest, and suppress exceptions     (_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)     // round down, and suppress exceptions     (_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)     // round up, and suppress exceptions     (_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)        // truncate, and suppress exceptions     _MM_FROUND_CUR_DIRECTION // use MXCSR.RC; see _MM_SET_ROUNDING_MODE (AVX512F)</summary>
        _MM_MASKZ_GETMANT_ROUND_SS,
        ///<summary>Normalize the mantissas of the lower double-precision (64-bit) floating-point element in a, store the result in the lower element of dst, and copy the upper element from b to the upper element of dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512F)</summary>
        _MM_GETMANT_SD,
        ///<summary>Normalize the mantissas of the lower double-precision (64-bit) floating-point element in a, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper element from b to the upper element of dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512F)</summary>
        _MM_MASK_GETMANT_SD,
        ///<summary>Normalize the mantissas of the lower double-precision (64-bit) floating-point element in a, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper element from b to the upper element of dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512F)</summary>
        _MM_MASKZ_GETMANT_SD,
        ///<summary>Normalize the mantissas of the lower single-precision (32-bit) floating-point element in a, store the result in the lower element of dst, and copy the upper 3 packed elements from b to the upper elements of dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512F)</summary>
        _MM_GETMANT_SS,
        ///<summary>Normalize the mantissas of the lower single-precision (32-bit) floating-point element in a, store the result in the lower element of dst using writemask k (the element is copied from src when mask bit 0 is not set), and copy the upper 3 packed elements from b to the upper elements of dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512F)</summary>
        _MM_MASK_GETMANT_SS,
        ///<summary>Normalize the mantissas of the lower single-precision (32-bit) floating-point element in a, store the result in the lower element of dst using zeromask k (the element is zeroed out when mask bit 0 is not set), and copy the upper 3 packed elements from b to the upper elements of dst. This intrinsic essentially calculates Â±(2^k)*|x.significand|, where k depends on the interval range defined by interv and the sign depends on sc and the source sign. 	The mantissa is normalized to the interval specified by interv, which can take the following values:    _MM_MANT_NORM_1_2     // interval [1, 2)     _MM_MANT_NORM_p5_2    // interval [0.5, 2)     _MM_MANT_NORM_p5_1    // interval [0.5, 1)     _MM_MANT_NORM_p75_1p5 // interval [0.75, 1.5)The sign is determined by sc which can take the following values:    _MM_MANT_SIGN_src     // sign = sign(src)     _MM_MANT_SIGN_zero    // sign = 0     _MM_MANT_SIGN_nan     // dst = NaN if sign(src) = 1 (AVX512F)</summary>
        _MM_MASKZ_GETMANT_SS,
        ///<summary>Determines the maximum of each pair of corresponding elements in packed double-precision (64-bit) floating-point elements in a and b, storing the results in dst. (KNCNI)</summary>
        _MM512_GMAX_PD,
        ///<summary>Determines the maximum of each pair of corresponding elements of packed double-precision (64-bit) floating-point elements in a and b, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_GMAX_PD,
        ///<summary>Determines the maximum of each pair of corresponding elements in packed single-precision (32-bit) floating-point elements in a and b, storing the results in dst. (KNCNI)</summary>
        _MM512_GMAX_PS,
        ///<summary>Determines the maximum of each pair of corresponding elements of packed single-precision (32-bit) floating-point elements in a and b, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_GMAX_PS,
        ///<summary>Determines the maximum of the absolute elements of each pair of corresponding elements of packed single-precision (32-bit) floating-point elements in a and b, storing the results in dst. (KNCNI)</summary>
        _MM512_GMAXABS_PS,
        ///<summary>Determines the maximum of the absolute elements of each pair of corresponding elements of packed single-precision (32-bit) floating-point elements in a and b, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_GMAXABS_PS,
        ///<summary>Determines the minimum of each pair of corresponding elements in packed double-precision (64-bit) floating-point elements in a and b, storing the results in dst. (KNCNI)</summary>
        _MM512_GMIN_PD,
        ///<summary>Determines the maximum of each pair of corresponding elements of packed double-precision (64-bit) floating-point elements in a and b, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_GMIN_PD,
        ///<summary>Determines the minimum of each pair of corresponding elements in packed single-precision (32-bit) floating-point elements in a and b, storing the results in dst. (KNCNI)</summary>
        _MM512_GMIN_PS,
        ///<summary>Determines the maximum of each pair of corresponding elements of packed single-precision (32-bit) floating-point elements in a and b, storing the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (KNCNI)</summary>
        _MM512_MASK_GMIN_PS,
        ///<summary>Horizontally add adjacent pairs of 16-bit integers in a and b, and pack the signed 16-bit results in dst. (SSSE3)</summary>
        _MM_HADD_EPI16,
        ///<summary>Horizontally add adjacent pairs of 16-bit integers in a and b, and pack the signed 16-bit results in dst. (AVX2)</summary>
        _MM256_HADD_EPI16,
        ///<summary>Horizontally add adjacent pairs of 32-bit integers in a and b, and pack the signed 32-bit results in dst. (SSSE3)</summary>
        _MM_HADD_EPI32,
        ///<summary>Horizontally add adjacent pairs of 32-bit integers in a and b, and pack the signed 32-bit results in dst. (AVX2)</summary>
        _MM256_HADD_EPI32,
        ///<summary>Horizontally add adjacent pairs of double-precision (64-bit) floating-point elements in a and b, and pack the results in dst. (SSE3)</summary>
        _MM_HADD_PD,
        ///<summary>Horizontally add adjacent pairs of double-precision (64-bit) floating-point elements in a and b, and pack the results in dst. (AVX)</summary>
        _MM256_HADD_PD,
        ///<summary>Horizontally add adjacent pairs of 16-bit integers in a and b, and pack the signed 16-bit results in dst. (SSSE3)</summary>
        _MM_HADD_PI16,
        ///<summary>Horizontally add adjacent pairs of 32-bit integers in a and b, and pack the signed 32-bit results in dst. (SSSE3)</summary>
        _MM_HADD_PI32,
        ///<summary>Horizontally add adjacent pairs of single-precision (32-bit) floating-point elements in a and b, and pack the results in dst. (SSE3)</summary>
        _MM_HADD_PS,
        ///<summary>Horizontally add adjacent pairs of single-precision (32-bit) floating-point elements in a and b, and pack the results in dst. (AVX)</summary>
        _MM256_HADD_PS,
        ///<summary>Horizontally add adjacent pairs of 16-bit integers in a and b using saturation, and pack the signed 16-bit results in dst. (SSSE3)</summary>
        _MM_HADDS_EPI16,
        ///<summary>Horizontally add adjacent pairs of 16-bit integers in a and b using saturation, and pack the signed 16-bit results in dst. (AVX2)</summary>
        _MM256_HADDS_EPI16,
        ///<summary>Horizontally add adjacent pairs of 16-bit integers in a and b using saturation, and pack the signed 16-bit results in dst. (SSSE3)</summary>
        _MM_HADDS_PI16,
        ///<summary>Horizontally subtract adjacent pairs of 16-bit integers in a and b, and pack the signed 16-bit results in dst. (SSSE3)</summary>
        _MM_HSUB_EPI16,
        ///<summary>Horizontally subtract adjacent pairs of 16-bit integers in a and b, and pack the signed 16-bit results in dst. (AVX2)</summary>
        _MM256_HSUB_EPI16,
        ///<summary>Horizontally subtract adjacent pairs of 32-bit integers in a and b, and pack the signed 32-bit results in dst. (SSSE3)</summary>
        _MM_HSUB_EPI32,
        ///<summary>Horizontally subtract adjacent pairs of 32-bit integers in a and b, and pack the signed 32-bit results in dst. (AVX2)</summary>
        _MM256_HSUB_EPI32,
        ///<summary>Horizontally subtract adjacent pairs of double-precision (64-bit) floating-point elements in a and b, and pack the results in dst. (SSE3)</summary>
        _MM_HSUB_PD,
        ///<summary>Horizontally subtract adjacent pairs of double-precision (64-bit) floating-point elements in a and b, and pack the results in dst. (AVX)</summary>
        _MM256_HSUB_PD,
        ///<summary>Horizontally subtract adjacent pairs of 16-bit integers in a and b, and pack the signed 16-bit results in dst. (SSSE3)</summary>
        _MM_HSUB_PI16,
        ///<summary>Horizontally subtract adjacent pairs of 32-bit integers in a and b, and pack the signed 32-bit results in dst. (SSSE3)</summary>
        _MM_HSUB_PI32,
        ///<summary>Horizontally add adjacent pairs of single-precision (32-bit) floating-point elements in a and b, and pack the results in dst. (SSE3)</summary>
        _MM_HSUB_PS,
        ///<summary>Horizontally add adjacent pairs of single-precision (32-bit) floating-point elements in a and b, and pack the results in dst. (AVX)</summary>
        _MM256_HSUB_PS,
        ///<summary>Horizontally subtract adjacent pairs of 16-bit integers in a and b using saturation, and pack the signed 16-bit results in dst. (SSSE3)</summary>
        _MM_HSUBS_EPI16,
        ///<summary>Horizontally subtract adjacent pairs of 16-bit integers in a and b using saturation, and pack the signed 16-bit results in dst. (AVX2)</summary>
        _MM256_HSUBS_EPI16,
        ///<summary>Horizontally subtract adjacent pairs of 16-bit integers in a and b using saturation, and pack the signed 16-bit results in dst. (SSSE3)</summary>
        _MM_HSUBS_PI16,
        ///<summary>Compute the length of the hypotenous of a right triangle, with the lengths of the other two sides of the triangle stored as packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst. (SSE)</summary>
        _MM_HYPOT_PD,
        ///<summary>Compute the length of the hypotenous of a right triangle, with the lengths of the other two sides of the triangle stored as packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst. (AVX)</summary>
        _MM256_HYPOT_PD,
        ///<summary>Compute the length of the hypotenous of a right triangle, with the lengths of the other two sides of the triangle stored as packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst. (AVX512F)</summary>
        _MM512_HYPOT_PD,
        ///<summary>Compute the length of the hypotenous of a right triangle, with the lengths of the other two sides of the triangle stored as packed double-precision (64-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_HYPOT_PD,
        ///<summary>Compute the length of the hypotenous of a right triangle, with the lengths of the other two sides of the triangle stored as packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst. (SSE)</summary>
        _MM_HYPOT_PS,
        ///<summary>Compute the length of the hypotenous of a right triangle, with the lengths of the other two sides of the triangle stored as packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst. (AVX)</summary>
        _MM256_HYPOT_PS,
        ///<summary>Compute the length of the hypotenous of a right triangle, with the lengths of the other two sides of the triangle stored as packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst. (AVX512F)</summary>
        _MM512_HYPOT_PS,
        ///<summary>Compute the length of the hypotenous of a right triangle, with the lengths of the other two sides of the triangle stored as packed single-precision (32-bit) floating-point elements in a and b, and store the results in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F)</summary>
        _MM512_MASK_HYPOT_PS,
        ///<summary>Up-converts 16 memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale using conv to 32-bit integer elements and stores them in dst. (AVX512F, KNCNI)</summary>
        _MM512_I32EXTGATHER_EPI32,
        ///<summary>Up-converts 16 single-precision (32-bit) memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale using conv to 32-bit integer elements and stores them in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_I32EXTGATHER_EPI32,
        ///<summary>Up-converts 16 memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale using conv to single-precision (32-bit) floating-point elements and stores them in dst. (AVX512F, KNCNI)</summary>
        _MM512_I32EXTGATHER_PS,
        ///<summary>Up-converts 16 single-precision (32-bit) memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale using conv to single-precision (32-bit) floating-point elements and stores them in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_I32EXTGATHER_PS,
        ///<summary>Down-converts 16 packed 32-bit integer elements in v1 using conv and stores them in memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale. hint indicates to the processor whether the data is non-temporal. (AVX512F, KNCNI)</summary>
        _MM512_I32EXTSCATTER_EPI32,
        ///<summary>Down-converts 16 packed 32-bit integer elements in v1 using conv and stores them in memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale. Elements are written using writemask k (elements are only written when the corresponding mask bit is set; otherwise, elements are left unchanged in memory). hint indicates to the processor whether the data is non-temporal. (AVX512F, KNCNI)</summary>
        _MM512_MASK_I32EXTSCATTER_EPI32,
        ///<summary>Down-converts 16 packed single-precision (32-bit) floating-point elements in v1 and stores them in memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale using conv. (AVX512F, KNCNI)</summary>
        _MM512_I32EXTSCATTER_PS,
        ///<summary>Down-converts 16 packed single-precision (32-bit) floating-point elements in v1 according to conv and stores them in memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale using writemask k (elements are written only when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_I32EXTSCATTER_PS,
        ///<summary>Gather 32-bit integers from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst. scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM_I32GATHER_EPI32,
        ///<summary>Gather 32-bit integers from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using mask (elements are copied from src when the highest bit is not set in the corresponding element). scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM_MASK_I32GATHER_EPI32,
        ///<summary>Gather 32-bit integers from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using writemask k (elements are copied from src when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM_MMASK_I32GATHER_EPI32,
        ///<summary>Gather 32-bit integers from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst. scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM256_I32GATHER_EPI32,
        ///<summary>Gather 32-bit integers from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using mask (elements are copied from src when the highest bit is not set in the corresponding element). scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM256_MASK_I32GATHER_EPI32,
        ///<summary>Gather 32-bit integers from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using writemask k (elements are copied from src when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM256_MMASK_I32GATHER_EPI32,
        ///<summary>Gather 32-bit integers from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst. scale should be 1, 2, 4 or 8. (AVX512F, KNCNI)</summary>
        _MM512_I32GATHER_EPI32,
        ///<summary>Gather 32-bit integers from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using writemask k (elements are copied from src when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512F, KNCNI)</summary>
        _MM512_MASK_I32GATHER_EPI32,
        ///<summary>Gather 64-bit integers from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst. scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM_I32GATHER_EPI64,
        ///<summary>Gather 64-bit integers from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using mask (elements are copied from src when the highest bit is not set in the corresponding element). scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM_MASK_I32GATHER_EPI64,
        ///<summary>Gather 64-bit integers from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using writemask k (elements are copied from src when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM_MMASK_I32GATHER_EPI64,
        ///<summary>Gather 64-bit integers from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst. scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM256_I32GATHER_EPI64,
        ///<summary>Gather 64-bit integers from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using mask (elements are copied from src when the highest bit is not set in the corresponding element). scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM256_MASK_I32GATHER_EPI64,
        ///<summary>Gather 64-bit integers from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using writemask k (elements are copied from src when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM256_MMASK_I32GATHER_EPI64,
        ///<summary>Gather 64-bit integers from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst. scale should be 1, 2, 4 or 8. (AVX512F)</summary>
        _MM512_I32GATHER_EPI64,
        ///<summary>Gather 64-bit integers from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using writemask k (elements are copied from src when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512F)</summary>
        _MM512_MASK_I32GATHER_EPI64,
        ///<summary>Gather double-precision (64-bit) floating-point elements from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst. scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM_I32GATHER_PD,
        ///<summary>Gather double-precision (64-bit) floating-point elements from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using mask (elements are copied from src when the highest bit is not set in the corresponding element). scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM_MASK_I32GATHER_PD,
        ///<summary>Gather double-precision (64-bit) floating-point elements from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using writemask k (elements are copied from src when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM_MMASK_I32GATHER_PD,
        ///<summary>Gather double-precision (64-bit) floating-point elements from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst. scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM256_I32GATHER_PD,
        ///<summary>Gather double-precision (64-bit) floating-point elements from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using mask (elements are copied from src when the highest bit is not set in the corresponding element). scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM256_MASK_I32GATHER_PD,
        ///<summary>Gather double-precision (64-bit) floating-point elements from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using writemask k (elements are copied from src when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM256_MMASK_I32GATHER_PD,
        ///<summary>Gather double-precision (64-bit) floating-point elements from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst. scale should be 1, 2, 4 or 8. (AVX512F)</summary>
        _MM512_I32GATHER_PD,
        ///<summary>Gather double-precision (64-bit) floating-point elements from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using writemask k (elements are copied from src when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512F)</summary>
        _MM512_MASK_I32GATHER_PD,
        ///<summary>Gather single-precision (32-bit) floating-point elements from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst. scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM_I32GATHER_PS,
        ///<summary>Gather single-precision (32-bit) floating-point elements from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using mask (elements are copied from src when the highest bit is not set in the corresponding element). scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM_MASK_I32GATHER_PS,
        ///<summary>Gather single-precision (32-bit) floating-point elements from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using writemask k (elements are copied from src when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM_MMASK_I32GATHER_PS,
        ///<summary>Gather single-precision (32-bit) floating-point elements from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst. scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM256_I32GATHER_PS,
        ///<summary>Gather single-precision (32-bit) floating-point elements from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using mask (elements are copied from src when the highest bit is not set in the corresponding element). scale should be 1, 2, 4 or 8. (AVX2)</summary>
        _MM256_MASK_I32GATHER_PS,
        ///<summary>Gather single-precision (32-bit) floating-point elements from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using writemask k (elements are copied from src when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM256_MMASK_I32GATHER_PS,
        ///<summary>Gather single-precision (32-bit) floating-point elements from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst. scale should be 1, 2, 4 or 8. (AVX512F, KNCNI)</summary>
        _MM512_I32GATHER_PS,
        ///<summary>Gather single-precision (32-bit) floating-point elements from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using writemask k (elements are copied from src when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512F, KNCNI)</summary>
        _MM512_MASK_I32GATHER_PS,
        ///<summary>Up-converts 8 double-precision (64-bit) memory locations starting at location mv at packed 32-bit integer indices stored in the lower half of index scaled by scale using conv to 64-bit integer elements and stores them in dst. (AVX512F, KNCNI)</summary>
        _MM512_I32LOEXTGATHER_EPI64,
        ///<summary>Up-converts 8 double-precision (64-bit) memory locations starting at location mv at packed 32-bit integer indices stored in the lower half of index scaled by scale using conv to 64-bit integer elements and stores them in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_I32LOEXTGATHER_EPI64,
        ///<summary>Up-converts 8 double-precision (64-bit) floating-point elements in memory locations starting at location mv at packed 32-bit integer indices stored in the lower half of index scaled by scale using conv to 64-bit floating-point elements and stores them in dst. (AVX512F, KNCNI)</summary>
        _MM512_I32LOEXTGATHER_PD,
        ///<summary>Up-converts 8 double-precision (64-bit) floating-point elements in memory locations starting at location mv at packed 32-bit integer indices stored in the lower half of index scaled by scale using conv to 64-bit floating-point elements and stores them in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_I32LOEXTGATHER_PD,
        ///<summary>Down-converts 8 packed 64-bit integer elements in v1 and stores them in memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale using conv. (AVX512F, KNCNI)</summary>
        _MM512_I32LOEXTSCATTER_EPI64,
        ///<summary>Down-converts 8 packed 64-bit integer elements in v1 and stores them in memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale using conv. Only those elements whose corresponding mask bit is set in writemask k are written to memory. (AVX512F, KNCNI)</summary>
        _MM512_MASK_I32LOEXTSCATTER_EPI64,
        ///<summary>Down-converts 8 packed double-precision (64-bit) floating-point elements in v1 and stores them in memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale using conv. (AVX512F, KNCNI)</summary>
        _MM512_I32LOEXTSCATTER_PD,
        ///<summary>Down-converts 8 packed double-precision (64-bit) floating-point elements in v1 and stores them in memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale using conv. Only those elements whose corresponding mask bit is set in writemask k are written to memory. (AVX512F, KNCNI)</summary>
        _MM512_MASK_I32LOEXTSCATTER_PD,
        ///<summary>Loads 8 64-bit integer elements from memory starting at location mv at packed 32-bit integer indices stored in the lower half of index scaled by scale and stores them in dst. (AVX512F, KNCNI)</summary>
        _MM512_I32LOGATHER_EPI64,
        ///<summary>Loads 8 64-bit integer elements from memory starting at location mv at packed 32-bit integer indices stored in the lower half of index scaled by scale and stores them in dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_I32LOGATHER_EPI64,
        ///<summary>Loads 8 double-precision (64-bit) floating-point elements stored at memory locations starting at location mv at packed 32-bit integer indices stored in the lower half of index scaled by scale them in dst. (AVX512F, KNCNI)</summary>
        _MM512_I32LOGATHER_PD,
        ///<summary>Loads 8 double-precision (64-bit) floating-point elements from memory starting at location mv at packed 32-bit integer indices stored in the lower half of index scaled by scale into dst using writemask k (elements are copied from src when the corresponding mask bit is not set). (AVX512F, KNCNI)</summary>
        _MM512_MASK_I32LOGATHER_PD,
        ///<summary>Stores 8 packed 64-bit integer elements located in v1 and stores them in memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale. (KNCNI)</summary>
        _MM512_I32LOSCATTER_EPI64,
        ///<summary>Stores 8 packed 64-bit integer elements located in v1 and stores them in memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale using writemask k (elements whose corresponding mask bit is not set are not written to memory). (KNCNI)</summary>
        _MM512_MASK_I32LOSCATTER_EPI64,
        ///<summary>Stores 8 packed double-precision (64-bit) floating-point elements in v1 and to memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale. (AVX512F, KNCNI)</summary>
        _MM512_I32LOSCATTER_PD,
        ///<summary>Stores 8 packed double-precision (64-bit) floating-point elements in v1 to memory locations starting at location mv at packed 32-bit integer indices stored in index scaled by scale. Only those elements whose corresponding mask bit is set in writemask k are written to memory. (AVX512F, KNCNI)</summary>
        _MM512_MASK_I32LOSCATTER_PD,
        ///<summary>Scatter 32-bit integers from a into memory using 32-bit indices. 32-bit elements are stored at addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM_I32SCATTER_EPI32,
        ///<summary>Scatter 32-bit integers from a into memory using 32-bit indices. 32-bit elements are stored at addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale) subject to mask k (elements are not stored when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM_MASK_I32SCATTER_EPI32,
        ///<summary>Scatter 32-bit integers from a into memory using 32-bit indices. 32-bit elements are stored at addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM256_I32SCATTER_EPI32,
        ///<summary>Scatter 32-bit integers from a into memory using 32-bit indices. 32-bit elements are stored at addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale) subject to mask k (elements are not stored when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM256_MASK_I32SCATTER_EPI32,
        ///<summary>Scatter 32-bit integers from a into memory using 32-bit indices. 32-bit elements are stored at addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). scale should be 1, 2, 4 or 8. (AVX512F, KNCNI)</summary>
        _MM512_I32SCATTER_EPI32,
        ///<summary>Scatter 32-bit integers from a into memory using 32-bit indices. 32-bit elements are stored at addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale) subject to mask k (elements are not stored when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512F, KNCNI)</summary>
        _MM512_MASK_I32SCATTER_EPI32,
        ///<summary>Scatter 64-bit integers from a into memory using 32-bit indices. 64-bit elements are stored at addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM_I32SCATTER_EPI64,
        ///<summary>Scatter 64-bit integers from a into memory using 32-bit indices. 64-bit elements are stored at addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale) subject to mask k (elements are not stored when the corresponding mask bit is not set). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM_MASK_I32SCATTER_EPI64,
        ///<summary>Scatter 64-bit integers from a into memory using 32-bit indices. 64-bit elements are stored at addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). scale should be 1, 2, 4 or 8. (AVX512VL, AVX512F)</summary>
        _MM256_I32SCATTER_EPI64
    }
}

.intel_syntax noprefix

include "inc\example.inc"
	jmp			FOO		# FOO is defined in an included file

	#region Things TODO

	mov			r13, QWORD PTR lennyOptions$[rsp]
	mov 		rsi, QWORD PTR [network_c_mp_network_neurons]
	vmovups		xmm4, XMMWORD PTR [.T1737_.0.17+64] # label not recognized
	vmovdqu		XMMWORD PTR [imagerel(htm_v1_constants_mp_global_cell_is_active_curr)+r13+r8], xmm15 

	lea			rcx, OFFSET FLAT:??_C@_0FE@OJFGMKFJ@ERROR?3?5dataset?3?3HexDataSet?3?3getV@
	mov			rax, -4616189618054758400		; negative constants not recognized bff0000000000000H

	#endregion Things TODO



	#region Calc Frequency with Avx512
	vcvttss2usi r8,xmm30,{sae}


	vpaddd 
	valignq 

	#endregion

	#region Comment examples
	# Singleline comment

	# Multiline comment 1a
	# Multiline comment 2a

	# Multiline comment 1b
	# Multiline comment 2b
	# Multiline comment 3b
	#endregion

	#region AVX-512 examples
	VALIGNQ zmm0 {k1}, zmm1, zmm2, 5 ; ok
	VALIGNQ zmm0, zmm1, zword [rax], 5			; packed 512-bit memory
	VALIGNQ zmm0, zmm1, qword [rax]{1to8}, 5 	; double-precision float broadcasted


	VDIVPS xmm4, xmm5, oword [rbx] 			; packed 128-bit memory
	VDIVPS ymm4, ymm5, yword [rbx] 			; packed 256-bit memory
	VDIVPS zmm4, zmm5, zword [rbx]          ; packed 512-bit memory

	VDIVPS xmm4, xmm5, dword [rbx]{1to4} 	; single-precision float broadcasted
	VDIVPS ymm4, ymm5, dword [rbx]{1to8} 	; single-precision float broadcasted
	VDIVPS zmm4, zmm5, dword [rbx]{1to16}   ; single-precision float broadcasted

	;VCVTPH2PS zmm1 {k1}{z}, ymm2/m256 {sae}
	;
	; Convert sixteen packed half precision (16-bit) floating-point values in ymm2/m256 to packed
	; single-precision floating-point values in zmm1.

	VCVTPH2PS zmm0{k1}, ymm1
	;VCVTPH2PS zmm0, ymm1 {0}
	vpconflictq zmm0{k7}{z},zmm1

	vcvttss2usi r8,xmm30 
	vcvttss2usi rax,xmm1,{sae} 
 
	vcvtss2usi rax,xmm30
	vcvtss2usi rax,xmm30,{rn-sae}
	vcvtss2usi rax,xmm30,{ru-sae}
	vcvtss2usi rax,xmm30,{rd-sae}
	vcvtss2usi rax,xmm30,{rz-sae} 


	;#region VCVTPS2UDQ
	;VCVTPS2UDQ zmm1 {k1}{z}, zmm2/m512/m32bcst{er}
	;Convert sixteen packed single-precision floating-point
	;values from zmm2/m512/m32bcst to sixteen packed
	;unsigned doubleword values in zmm1 subject to
	;writemask k1.
	vcvtps2udq zmm0,zmm1
	vcvtps2udq zmm0,zmm1,{rz-sae}
	vcvtps2udq xmm0,xmm1
	vcvtps2udq zmm0{k7},zmm1
	vcvtps2udq zmm0{k7}{z},zmm1
	vcvtps2udq zmm0,zmm1,{rn-sae}
	vcvtps2udq zmm0,zmm1,{ru-sae}
	vcvtps2udq zmm0,zmm1,{rd-sae}
	vcvtps2udq zmm0,zmm1,{rz-sae}
	vcvtps2udq zmm0,ZWORD [rcx]
	vcvtps2udq zmm0,DWORD [rcx]{1to16}
	;vcvtps2udq zmm0,ZWORD [rcx],{rz-sae} ;error: Embedded rounding is available only with reg-reg op.


	;#endregion

	vpscatterdd  [r14+zmm31*8+0x7b]{k1},zmm30


	#endregion


	#region Jump Examples
	jmp			$LL9@run.cpu$om
	jmp			SHORT $LL9@run.cpu$om
	jmp			$
	jmp			NEAR ptr $
	jmp			SHORT $+2
	jmp			rax

	??$?6U?$char_traits@D@std@@@std@@YAAEAV?$basic_ostream@DU?$char_traits@D@std@@@0@AEAV10@PEBD@Z:
	call		??$?6U?$char_traits@D@std@@@std@@YAAEAV?$basic_ostream@DU?$char_traits@D@std@@@0@AEAV10@PEBD@Z

	#endregion

	#region Nasm Examples

_str_wi:
    enter 16,0
    mov ebx,[ebp + 8]
    mov ecx,[ebp + 12]
    mov dl,[ebp + 16]
    cmp ecx,0
    je .end

loop:
    inc ebx
    loop loop
.end:
    mov [ebx],dl
    leave
    ret

_str_ri:
    enter 12,0
    mov si,[ebp + 8]
    mov ecx,[ebp + 12]
    loop .loop
.loop:
    lodsb

	#endregion 

	#region Masm Examples

segment_name SEGMENT USE64
    ASSUME gs:NOTHING
    mov eax, dword ptr gs:[0]
segment_name ENDS

segment_name SEGMENT USE64 # make code folding
    db "This string contains the word jmp inside of it",0
    FOO2 EQU 0x00
    mylabel LABEL near

    call proc_name
    jmp dword ptr [eax]
    jmp FOO2
    jmp mylabel
proc_name PROC # add id to label graph and make code folding
    xor rax, rax
    ret
proc_name ENDP
segment_name ENDS

	@@:
	jmp $F
	jmp $B
	alias label_alias = FOO
	jmp label_alias
	@@:

	#endregion

	#region Label Clash Example
$LL9@run.cpu$om: # multiple label definitions
$LL9@run.cpu$om: xor rax, rax
	#endregion

	#region All Registers

	rax 
	Rax
	RAX
	rax1
    EAX 
    AX 
    AL 
    AH 

    RBX 
    EBX 
    BX 
    BL 
    BH 

    RCX 
    ECX 
    CX 
    CL 
    CH 

    RDX 
    EDX 
    DX 
    DL 
    DH 

    RSI 
    ESI 
    SI 
    SIL 

    RDI 
    EDI 
    DI 
    DIL 

    RBP 
    EBP 
    BP 
    BPL 

    RSP 
    ESP 
    SP 
    SPL 

    R8 
    R8D 
    R8W 
    R8B 

    R9 
    R9D 
    R9W 
    R9B 

    R10 
    R10D 
    R10W 
    R10B 

    R11 
    R11D 
    R11W 
    R11B 

    R12 
    R12D 
    R12W 
    R12B 

    R13 
    R13D 
    R13W 
    R13B 

    R14 
    R14D 
    R14W 
    R14B 

    R15 
    R15D 
    R15W 
    R15B

    MM0 
    MM1 
    MM2 
    MM3 
    MM4 
    MM5 
    MM6 
    MM7 

    XMM0 
    XMM1 
    XMM2 
    XMM3 
    XMM4 
    XMM5 
    XMM6 
    XMM7 

    XMM8 
    XMM9 
    XMM10 
    XMM11 
    XMM12 
    XMM13 
    XMM14 
    XMM15 

    YMM0 
    YMM1 
    YMM2 
    YMM3 
    YMM4 
    YMM5 
    YMM6 
    YMM7 

    YMM8 
    YMM9 
    YMM10 
    YMM11 
    YMM12 
    YMM13 
    YMM14 
    YMM15 

    ZMM0 
    ZMM1 
    ZMM2 
    ZMM3 
    ZMM4 
    ZMM5 
    ZMM6 
    ZMM7 

    ZMM8 
    ZMM9 
    ZMM10 
    ZMM11 
    ZMM12 
    ZMM13 
    ZMM14 
    ZMM15 

    ZMM16 
    ZMM17 
    ZMM18 
    ZMM19 
    ZMM20 
    ZMM21 
    ZMM22 
    ZMM23 

    ZMM24 
    ZMM25 
    ZMM26 
    ZMM27 
    ZMM28 
    ZMM29 
    ZMM30 
    ZMM31 
	#endregion

	#region Real Example Handcoded

# void bitswap_gas(unsigned int * const data, const unsigned long long pos1, const unsigned long long pos2) // rcx, rdx, r8, r9
# rcx <= data
# rdx <= pos1
# r8 <= pos2
# https://msdn.microsoft.com/en-us/library/9z1stfyw.aspx
# https://software.intel.com/sites/landingpage/IntrinsicsGuide/

.text                                           # Code section
.global bitswap_gas
bitswap_gas:

	mov         r9,rdx
	shr         rdx,5
	and         r9,0x1F

	mov         r10,r8
	shr         r8,5
	and         r10,0x1F

	btr         dword [rcx+4*rdx],r9d
	jnc         label1

	bts         dword [rcx+4*r8],r10d
	jmp         label2
label1:
	btr         dword [rcx+4*r8],r10d
label2:
	jnc         label3
	bts         dword [rcx+4*rdx],r9d
label3:
	ret
.att_syntax

#000000013F2CB440 4C 8B CA             mov         r9,rdx  
#000000013F2CB443 4D 8B D0             mov         r10,r8  
#000000013F2CB446 48 C1 EA 05          shr         rdx,5  
#000000013F2CB44A 49 C1 E8 05          shr         r8,5  
#000000013F2CB44E 49 83 E1 1F          and         r9,1Fh  
#000000013F2CB452 49 83 E2 1F          and         r10,1Fh  
#000000013F2CB456 44 0F B3 0C 91       btr         dword ptr [rcx+rdx*4],r9d  
#000000013F2CB45B 73 07                jae         bitswap_asm+24h (013F2CB464h)  
#000000013F2CB45D 46 0F AB 14 81       bts         dword ptr [rcx+r8*4],r10d  
#000000013F2CB462 EB 05                jmp         bitswap_asm+29h (013F2CB469h)  
#000000013F2CB464 46 0F B3 14 81       btr         dword ptr [rcx+r8*4],r10d  
#000000013F2CB469 73 05                jae         bitswap_asm+30h (013F2CB470h)  
#000000013F2CB46B 44 0F AB 0C 91       bts         dword ptr [rcx+rdx*4],r9d  
#000000013F2CB470 C3                   ret  
#endregion
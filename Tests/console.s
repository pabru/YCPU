; interrupt table
.dat main,  0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000
.dat 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000


main:
.scope
	_local:
	.scope
		inc r0
		_local:
		baw _local
	.scend
	.scope
		baw _local
	.scend
.scend

_local:
.incbin "console.yasm", 10, 100
## zerodaycrypto

| Author | Difficulty | Points | Solves | First Blood    | Time to Blood  |
| ------ | ---------- | ------ | ------ | -------------- | -------------- |
| Neobeo | Append (6) | 439    | 4      | thehackerscrew | 1 day, 4 hours |

---

### Description

Tags: `0day`, `Bounty`

<blockquote>

Obviously zerolinecrypto is not possible, so here's the next best thing.

`assert __import__('re').fullmatch(rb'SEKAI{\w{32}}', flag:=input().encode()) and [pow(int.from_bytes(flag[6:-1], 'big') + i, -1, 2**255-19) >> 170 for i in range(1+3+3+7)] == [29431621415867921698671444, 12257315102018176664717361, 6905311467813097279935853, 13222913226749606936127836, 25445478808277291772285314, 9467767007308649046406595, 33796240042739223741879633, 520979008712937962579001, 31472015353079479796110447, 38623718328689304853037278, 17149222936996610613276307, 21988007084256753502814588, 11696872772917077079195865, 6767350497471479755850094]`

> ❖ **Note**  
> US$100 bounty for the first solver.

<details closed>
<summary><b>Hint(s)</b>:</summary>

1. The intended solve uses only 10 outputs and takes about a minute, most of which is reducing a 232x232 lattice. Super Beetle Gamer might come in useful. A paper has been attached as part of the hint.

</details>
</blockquote>

### Challenge Files

* [zerodaycrypto_hint.pdf](solution/zerodaycrypto_hint.pdf)

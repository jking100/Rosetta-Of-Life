## Algorithm

Each generation, every cell is evaluated by checking the surrounding subset of the grid to determine the cell's neighbor count. Then, the rules of the simulation are applied.

- **Time complexity to process a grid of size `[n, n]`:** `O(n^2)`

---

## Possible Areas of Improvement

- **Increase Generations/Sec:**  
  Distribute grid checking across multiple threads to parallelize computation.

- **Decrease Algorithmic Cost:**  
  Track only live cells, and process just them and their immediate neighbors.

---

## Current Algorithm Benchmark  
**(Square grids with basic wrap-around: top-bottom, left-right)**

```
Timing Diagnostics: Grid Size vs Generations

GridSize\Gens   128       256       512       1024
-------------------------------------------------------
32              27ms      51ms      110ms     205ms
64              103ms     209ms     427ms     817ms
128             406ms     875ms     1617ms    3367ms
256             1749ms    3550ms    6872ms    13996ms
```

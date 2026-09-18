# ✅ TODO — Flappy Me

## 🔥 In progress
- [ ] Commit, PR and merge `feature/parallax-background`

## 📋 Next
**Art (Phase 6)**
- [ ] 🌳 Review the trees (the only thing not 100% convincing yet)
- [ ] Decide the obstacles (pipes are still placeholders): cantera columns, cathedral towers, yácatas...
- [ ] Obstacle sprites: tileable body + cap (`Draw Mode: Tiled`)
- [ ] Align the `Ground` collider with the sidewalk (Y ≈ -4.33) and check pipe `minY` (-1.5?)
- [ ] `player_hit` pose for Game Over
- [ ] UI font and styling
- [ ] App icon
- [ ] Optional: retouch the downscaled viejito and butterfly in Piskel

**Atmosphere**
- [ ] 🏮 Street lamps (faroles) along the sidewalk
- [ ] 🌙 Day/night cycle: sky and layers change tint over time
- [ ] Lamps turn on at night (glow / Light 2D) to set the mood

**Phase 5 — Game feel** — `feature/game-feel`
- [ ] Progressive difficulty (speed / gap by score)
- [ ] Camera shake on hit
- [ ] Final tuning pass

**Phase 7 — Audio** — `feature/audio`
- [ ] Jump, score and hit sounds
- [ ] Optional background music

**Phase 8 — Build and release** — `chore/release`
- [ ] Windows build
- [ ] WebGL build → itch.io
- [ ] GitHub Release → tag `v1.0`

## 💡 Ideas (later)
- [ ] More ambient characters (street vendors, pigeons...)
- [ ] Jacarandas in bloom (Morelia's spring)
- [ ] Ceiling that blocks instead of killing (like the original Flappy Bird)
- [ ] Option to stack jumps (`stackJumps` + `maxUpSpeed`) — tested idea, not used
- [ ] Medals / achievements by score
- [ ] Android build

## 🐛 Known bugs
- (none)

## ✔️ Done
**Setup**
- [x] Project plan
- [x] GitHub repo + Git LFS
- [x] Initial Unity project
- [x] Naming conventions
- [x] Secrets patterns in `.gitignore`
- [x] `docs/` with PLAN, DEVLOG and TODO
- [x] `_Project` folder structure

**Phase 3 — Core gameplay**
- [x] Player with jump (jumpForce 9, gravity 3)
- [x] Player rotation based on velocity
- [x] `Pipe` prefab that moves left and destroys itself
- [x] `PipeSpawner` with random heights
- [x] Ground and ceiling colliders
- [x] Game Over on collision
- [x] Score trigger in the gap

**Phase 4 — Game flow**
- [x] `GameManager` with Ready → Playing → GameOver states
- [x] Start screen and Game Over screen
- [x] Restart button
- [x] Score UI with TextMeshPro
- [x] High score with `PlayerPrefs`
- [x] 🎯 Milestone 1 — tag `v0.1`

**Phase 6 — Art**
- [x] Wingsuit character (front view, green suit), 3 frames
- [x] Import settings: PPU 24, Point, no compression
- [x] `PlayerFly` animation
- [x] Sorting Layers: Sky, Background, Ambient, Obstacles, Player
- [x] Backgrounds at 480×240: sky, trees, Morelia aqueduct + street
- [x] `ParallaxLayer` with 3 layers
- [x] Monarch butterfly and viejito animations + prefabs
- [x] `AmbientMover` (camera-based destroy) and `AmbientSpawner` (spawn on start, max alive)

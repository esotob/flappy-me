# ✅ TODO — Flappy Me

## 🔥 In progress
**Phase 6 — Art** — `feature/art`
- [ ] Decide character style (avatar / pixel art, not a real photo — public repo)
- [ ] Player sprite + import settings (Pixels Per Unit, Filter Mode)
- [ ] Flap animation (2–3 frames)
- [ ] Hit / fall pose
- [ ] Pipe sprites
- [ ] Background + visible ground
- [ ] UI font and styling
- [ ] App icon

## 📋 Next
**Phase 5 — Game feel** — `feature/game-feel`
- [ ] Progressive difficulty (speed / gap by score)
- [ ] Parallax background
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
- [ ] Visible decorative ground (current one sits off-camera)
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

# ✅ TODO — Flappy Me

## 📋 Next
**Phase 3.6–3.8** — `feature/collisions-and-score`
- [ ] Ground and ceiling with colliders
- [ ] Game Over on collision (`OnCollisionEnter2D`)
- [ ] Invisible score trigger in the pipe gap (`OnTriggerEnter2D`)
- [ ] Stop pipes and spawner on Game Over

**Phase 4** — `feature/game-flow`
- [ ] `GameManager` with states: Start → Playing → GameOver
- [ ] Start screen: "Tap to start" (player floats, no gravity)
- [ ] Game Over screen with Restart button
- [ ] Score UI with TextMeshPro
- [ ] High score with `PlayerPrefs`
- [ ] 🎯 Milestone 1: tag `v0.1`

## 💡 Ideas (later)
- [ ] "Flappy Me" character (avatar/pixel art instead of a real photo, repo is public)
- [ ] Flap and hit animations
- [ ] Parallax background
- [ ] Jump, score and hit sounds
- [ ] Progressive difficulty
- [ ] Camera shake on hit
- [ ] Option to stack jumps (`stackJumps` + `maxUpSpeed`) — tested idea, not used
- [ ] Publish on itch.io (WebGL)

## 🐛 Known bugs
- (none yet)
- Expected for now: player falls off-screen (no ground) and bounces off pipes (no Game Over)

## ✔️ Done
- [x] Project plan
- [x] GitHub repo + Git LFS
- [x] Initial Unity project
- [x] Naming conventions
- [x] Secrets patterns in `.gitignore`
- [x] `docs/` with PLAN, DEVLOG and TODO
- [x] `_Project` folder structure
- [x] Scene moved to `_Project/Scenes/Game`
- [x] Player with jump (jumpForce 9, gravity 3)
- [x] Player rotation based on velocity
- [x] `Pipe` prefab that moves left and destroys itself
- [x] `PipeSpawner` with random heights
- [x] Commit, PR and merge `feature/pipes` (if not done yet)

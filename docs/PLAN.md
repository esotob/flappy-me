# 🐦 Flappy Me — Project Plan

A simple Flappy Bird–style game where **I am the one flying**.
Goal: learn Unity fundamentals by building it right, from scratch.

**Approach:** first make it fully **functional with simple shapes**, then add art, audio and polish.

---

## 📐 Conventions

| Item | Convention | Example |
|---|---|---|
| Branches | `type/kebab-case` | `feature/player-movement` |
| Commits | `type: imperative verb` | `feat: add player jump` |
| Folders | PascalCase | `Scripts`, `Prefabs` |
| Scripts / classes | PascalCase | `PlayerController.cs` |
| Methods | PascalCase | `Jump()` |
| Variables / fields | camelCase | `jumpForce` |
| Scenes / prefabs | PascalCase | `Game`, `Pipe` |
| Docs | UPPERCASE `.md` | `DEVLOG.md` |

**Types:** `feature/` · `feat:` (new functionality) — `fix/` · `fix:` (bug fix) — `chore/` · `chore:` (setup, config) — `docs/` · `docs:` (documentation)

**Workflow:** `main` is always stable. Work on a branch → push → Pull Request → merge → `git pull` on `main`.

---

## Phase 0 — Environment setup ✅
- [x] Unity Hub + Unity LTS
- [x] Visual Studio
- [x] Git for Windows (includes Git LFS)
- [x] `git lfs install`
- [x] Global Git identity (`user.name`, `user.email`)

> Note: Unity runs on Windows, so the repo lives on the Windows filesystem (not WSL).

## Phase 1 — Repository and project ✅
- [x] GitHub repo `flappy-me` with README and Unity `.gitignore`
- [x] Clone to `Documents\flappy-me`
- [x] Create Unity project (Universal 2D) and move it to the repo root
- [x] Editor settings: **Visible Meta Files** + **Force Text**
- [x] `.gitattributes` with LFS patterns (images, audio, fonts, 3D)
- [x] First commit and push

## Phase 2 — Structure and documentation
**Branch:** `chore/project-structure`

- [ ] `docs/` folder at repo root (outside `Assets/`)
  - [ ] `PLAN.md` — this plan
  - [ ] `DEVLOG.md` — daily log (done, learned, problems, next)
  - [ ] `TODO.md` — in progress, next, ideas, bugs, done
- [ ] Folder structure in Unity:
  ```
  Assets/
    _Project/
      Scenes/
      Scripts/
      Prefabs/
      Sprites/
      Audio/
  ```
- [ ] Move `SampleScene` to `_Project/Scenes/` and rename it `Game` (inside Unity)
- [ ] Commit, push, Pull Request, merge

**Daily routine:** read the last DEVLOG "Next" and TODO "In progress" when starting; update both and commit when finishing.

## Phase 3 — Core gameplay (simple shapes)

### 3.1–3.3 Player
**Branch:** `feature/player-movement`
- [ ] Player: square/circle with `Rigidbody2D` + `CircleCollider2D`
- [ ] `PlayerController`: jump on click / space (set upward velocity)
- [ ] Slight rotation based on vertical velocity

### 3.4–3.5 Pipes
**Branch:** `feature/pipes`
- [ ] `Pipe` prefab: top and bottom rectangles with a gap
- [ ] Move left and destroy when off-screen
- [ ] `PipeSpawner`: spawn every X seconds at random heights

### 3.6–3.8 Collisions and score
**Branch:** `feature/collisions-and-score`
- [ ] Ground and ceiling colliders
- [ ] Collision → Game Over (`OnCollisionEnter2D`)
- [ ] Invisible trigger in the gap → +1 point (`OnTriggerEnter2D`)

## Phase 4 — Game flow
**Branch:** `feature/game-flow`
- [ ] `GameManager` with states: **Start → Playing → GameOver**
- [ ] Start screen: "Tap to start" (player floats, no gravity)
- [ ] Game Over screen with **Restart** button (reload scene)
- [ ] UI (TextMeshPro): current score
- [ ] High score saved with `PlayerPrefs`

🎯 **Milestone 1:** fully playable game with shapes → tag `v0.1`

## Phase 5 — Game feel
**Branch:** `feature/game-feel`
- [ ] Tune gravity, jump force, speed and pipe spacing
- [ ] Progressive difficulty (faster / smaller gap as score grows)
- [ ] Simple parallax background
- [ ] Camera shake on hit

## Phase 6 — "Flappy Me" art 🎨
**Branch:** `feature/art`
- [ ] Character: my face/avatar (stylized photo or pixel art)
- [ ] Flap animation (2–3 frames) and hit animation
- [ ] Themed pipes, background and ground
- [ ] Custom font, UI and app icon
- [ ] Replace placeholder sprites in prefabs

## Phase 7 — Audio
**Branch:** `feature/audio`
- [ ] Jump, score and hit sound effects
- [ ] Optional background music

## Phase 8 — Build and release
**Branch:** `chore/release`
- [ ] Windows build
- [ ] WebGL build → publish on **itch.io**
- [ ] Optional: Android
- [ ] GitHub Release → tag `v1.0`

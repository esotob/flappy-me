# 📓 Devlog — Flappy Me

Newest entries on top. Format: done, learned, problems, next.

---

## 2026-09-17

### ✅ Done
**Collisions and score (Phase 3.6–3.8)** — `feature/collisions-and-score`
- `Ground` and `Ceiling`: static colliders placed at Y -5.5 and 5.5, just outside the camera, so you only lose when actually leaving the screen.
- `Player` tagged as `Player`.
- `GameManager` (singleton) with score, game over and `Time.timeScale = 0`.
- `OnCollisionEnter2D` on the player → Game Over.
- `ScoreZone`: trigger child in the `Pipe` prefab that adds a point and disables itself.
- First real playthrough: **score 14**.

**Game flow and UI (Phase 4)** — `feature/game-flow`
- Imported TMP Essential Resources.
- `GameManager` rewritten with `GameState` enum: Ready → Playing → GameOver.
- High score saved with `PlayerPrefs`.
- `Restart()` reloads the scene with `SceneManager.LoadScene`.
- `UIManager` separated from `GameManager` (logic vs presentation).
- Player floats (gravity 0) until the first tap; `PipeSpawner` only spawns while Playing.
- UI: `ScoreText`, `ReadyPanel` (title + "Tap to start"), `GameOverPanel` (score, best, Restart button).
- 🎯 **Milestone 1: playable prototype** → tag `v0.1`.

### 🧠 Learned
- **Collision vs Trigger:** collision blocks and notifies; trigger (`Is Trigger`) is crossed and notifies. Score zones are triggers.
- Static colliders (walls, ground) don't need a `Rigidbody2D`.
- Colliders inherit the Transform scale, so Size stays at 1×1.
- Tags identify objects by code: `CompareTag("Player")`.
- **Singleton** (`static Instance`) gives global access without dragging references.
- **Guard clauses** (`if (...) return;`) keep methods from running in the wrong state.
- An `enum` for states is clearer and safer than several booleans.
- `Time.timeScale = 0` freezes everything and is global: it must be reset to 1 on restart.
- `PlayerPrefs` persists data between sessions.
- `SceneManager.LoadScene(buildIndex)` is the simplest way to restart.
- Separating `GameManager` (logic) from `UIManager` (presentation) keeps changes isolated.
- UI needs: `Canvas` + `Canvas Scaler` (Scale With Screen Size, 1920×1080) + **`Graphic Raycaster`** + `EventSystem`.
- Anchors decide what part of the screen an element is positioned against.
- In the Hierarchy, elements further down are drawn on top; `Raycast Target` decides what steals clicks.

### 🐛 Problems
- Ground and ceiling didn't trigger Game Over → the whole collider component was disabled.
- `ScoreText` ended up inside the `EventSystem` object; that object actually had `Canvas` + `Canvas Scaler` too (renamed it `UI`).
- The Restart button did nothing → the Canvas was missing its **`Graphic Raycaster`**.

### ➡️ Next
- Phase 6: "Flappy Me" art on `feature/art`.

---

## 2026-09-14

### ✅ Done
**Setup (Phases 0–1)**
- Created the project plan by phases (`docs/PLAN.md`).
- Created the public `flappy-me` GitHub repo with the Unity `.gitignore`.
- Installed and configured Git LFS with `.gitattributes`.
- Created the Unity 6 project (Universal 2D) and moved it to the repo root.
- First commit and push.
- Defined English naming conventions for branches, commits and code.

**Structure (Phase 2)** — `chore/project-structure`
- Added `docs/` with PLAN, DEVLOG and TODO.
- Created `Assets/_Project/` with `Audio`, `Prefabs`, `Scenes`, `Scripts`, `Settings`, `Sprites`.
- Moved and renamed `SampleScene` → `_Project/Scenes/Game`.
- Deleted the template `Welcome` folder.
- Added secrets patterns to `.gitignore` (`*.keystore`, `*.jks`, `*.env`, `secrets/`).
- First Pull Request and merge.

**Player (Phase 3.1–3.3)** — `feature/player-movement`
- `Player`: Square sprite + `Rigidbody2D` (Interpolate, Freeze Rotation Z) + `CircleCollider2D` (smaller hitbox).
- `PlayerController`: jump with space / click / touch (new Input System) and rotation based on vertical velocity.

**Pipes (Phase 3.4–3.5)** — `feature/pipes`
- `Pipe` prefab: empty parent with `Top` and `Bottom` children, kinematic `Rigidbody2D`, `BoxCollider2D` on each child.
- `Pipe` script: moves left with constant velocity and destroys itself off-screen.
- `PipeSpawner`: timer with `Time.deltaTime`, random gap height.

### 🎛️ Tuning values
| Setting | Value | Notes |
|---|---|---|
| `jumpForce` | 9 | 6 felt weak |
| `Gravity Scale` | 3 | 2 felt floaty |
| Pipe `speed` | 3 | |
| `spawnInterval` | 1.8 | Distance between pipes = speed × interval = 5.4 |
| Gap size | 3 | `Top` Y 6.5 / `Bottom` Y -6.5, scale Y 10 |
| Spawn Y range | -2 to 2 | |
| Spawn / destroy X | 10 / -12 | Camera size 5 → visible Y -5 to 5 |
| Ground / Ceiling Y | -5.5 / 5.5 | Just outside the camera |

### 🧠 Learned
**Git**
- Git stores text efficiently, but binaries bloat the repo → Git LFS.
- `git lfs install` only enables LFS; `.gitattributes` defines which files it tracks.
- `Library/`, `Temp/` and `Logs/` are regenerated and never committed.
- Git doesn't track moves: before `git add` they show as `deleted` + `untracked`; after, as `renamed`.
- Work on branches, keep `main` stable, review "Files changed" in the PR.
- In a public repo, anything pushed should be considered exposed.

**Unity**
- `.meta` files hold asset IDs; always move/rename inside Unity.
- **Force Text** serialization lets Git diff scenes and prefabs.
- GameObjects are containers; behavior comes from components.
- Changes made in Play mode are lost when stopping.
- `Update` (every frame) for input; `FixedUpdate` (fixed rate) for physics.
- `[SerializeField] private` → private in code, editable in the Inspector.
- Setting velocity (instead of adding) makes every jump identical; rapid taps don't stack.
- Jump height = velocity² ÷ (2 × gravity).
- Moving objects with colliders need a `Rigidbody2D` (Kinematic if moved by code).
- Child positions are relative to the parent.
- Prefabs are templates: edit once, all copies update. Assign prefabs from the Project folder, not from the scene.
- `Time.deltaTime` makes timers frame-rate independent.

### 🐛 Problems
- `git lfs install` failed in WSL → Unity runs on Windows, switched to Git for Windows.
- Pasted the repo URL without `git clone`.
- Unity Hub's GitHub option would have created a second repo → removed it.
- Notepad didn't save `.gitattributes` correctly at first.
- Folders weren't created and the scene was loose in `_Project` → recreated inside Unity.
- Jump felt weak and rapid taps "interrupted" the rise → by design; fixed with higher jumpForce + gravity.
- Pipes looked wrong (one rectangle each) → there was a loose `Pipe` in the scene outside the spawner. **Lesson:** check the Hierarchy outside Play mode.

# 📓 Devlog — Flappy Me

Newest entries on top. Format: done, learned, problems, next.

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

### ➡️ Next
- Phase 3.6–3.8 on `feature/collisions-and-score`:
  - Ground and ceiling colliders.
  - Game Over on collision.
  - Score trigger in the pipe gap.

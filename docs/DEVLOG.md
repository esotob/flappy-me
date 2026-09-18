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

**Player art (Phase 6)** — `feature/art`
- Character: me in a **wingsuit** ("traje de ardilla voladora"), pixel art made in Piskel, 32×32.
- Tried a side-view reference and an orange suit → kept the **front view** and the **green suit**.
- 3 frames: `player_up`, `player_mid`, `player_down` (only the arms/membrane move).
- Import: **PPU 24** (sprite = 1.33 units), **Filter Mode Point**, **Compression None**.
- `PlayerFly` animation clip + Animator Controller, ~10 samples.
- Rotation reduced for the front view (`maxUpAngle` / `maxDownAngle`).
- First PNGs stored with Git LFS.

**Parallax background and ambient (Phase 5/6)** — `feature/parallax-background`
- Sorting Layers: `Sky`, `Background`, `Ambient`, `Obstacles`, `Player`.
- Backgrounds redone at the right scale (480×240 px → 20×10 units at PPU 24):
  - `bg_sky`: dithered gradient + clouds.
  - `bg_aqueduct`: Morelia's aqueduct in cantera rosa (8 arches, 60 px each) + sidewalk + street.
  - `bg_trees`: dense forest drawn at 160×80 and scaled ×3 (chunky pixels, like my reference).
- All layers are tileable (no visible seam).
- `ParallaxLayer`: two copies per layer in a carousel; no state guard, so it also scrolls in the menu.
- Ambient characters, downscaled from my own art:
  - **Monarch butterfly** 🦋 (19×22 px, 3 frames, 12 samples).
  - **Viejito** from the *Danza de los Viejitos* 👴 (28×44 px, 3 frames, 6 samples), walking on the sidewalk.
- `AmbientMover`: reusable script (speed + optional sine wave), destroys itself when leaving the camera on either side.
- `AmbientSpawner`: reusable spawner with random interval, **spawn on start** and **max alive**.

### 🎛️ Tuning values
| Setting | Value | Notes |
|---|---|---|
| Player PPU | 24 | 32 looked too small |
| Background PPU / tileWidth | 24 / 20 | 480 px ÷ 24 = 20 units |
| Parallax speeds | Sky 0.2 · Trees 0.5 · Aqueduct 1.0 | Farther = slower |
| Sidewalk top | Y -3.83 | (120 − 212) ÷ 24 |
| Old man Y | -2.92 | Sidewalk + half his height |
| Old man speed | 0.5 facing right / 1.5 flipped | Relative to the aqueduct layer (1.0) to avoid foot sliding |
| Butterfly | speed 2, wave 0.4, freq 3 | |
| Max alive | Old man 1 · Butterflies 3 | |

### 🧠 Learned
**Physics and game logic**
- **Collision vs Trigger:** collision blocks and notifies; trigger (`Is Trigger`) is crossed and notifies.
- Static colliders (walls, ground) don't need a `Rigidbody2D`.
- Colliders inherit the Transform scale, so Size stays at 1×1.
- Tags identify objects by code: `CompareTag("Player")`.
- **Singleton** (`static Instance`) gives global access without dragging references.
- **Guard clauses** keep methods from running in the wrong state.
- An `enum` for states is clearer than several booleans.
- `Time.timeScale = 0` freezes everything and is global: reset it to 1 on restart.
- `PlayerPrefs` persists data between sessions.

**UI**
- UI needs `Canvas` + `Canvas Scaler` (Scale With Screen Size, 1920×1080) + **`Graphic Raycaster`** + `EventSystem`.
- Anchors decide what part of the screen an element is positioned against.
- Elements further down in the Hierarchy are drawn on top; `Raycast Target` decides what steals clicks.

**Art and animation**
- **Pixels Per Unit:** size in units = pixels ÷ PPU. Scale pixel art with PPU, not with the Transform.
- **Filter Mode Point** keeps pixel art sharp; Bilinear blurs it.
- Huge "pixel art style" images don't work as sprites: they must be drawn (or reduced) at the real pixel size.
- **Animation** = the clip (frames); **Animator** = the state machine that picks the clip. Sample rate sets the speed.
- In a flap animation only the limbs move; head and body stay on the same pixels.
- The player must always contrast with obstacles and background.
- **Layer** (physics/cameras) ≠ **Sorting Layer** (draw order, in the Sprite Renderer → Additional Settings).
- **Parallax:** far layers move slower. Tileable images: the right edge continues the left one.
- **Foot sliding:** a walker's speed must be relative to the ground layer's speed.
- Gameplay should be predictable (fixed pipe interval); ambient should feel random.
- **Reuse:** one script with parameters (`AmbientMover`, `AmbientSpawner`) instead of one per object.
- `Mathf.Sin` + a random offset → natural, non-synchronized floating motion.
- Camera bounds: half width = `orthographicSize * aspect`.

**Unity / Git**
- The Inspector shows **local** position for children; scripts using `transform.position` use **world** position.
- `transform.childCount` is an easy way to count spawned objects.
- Git collapses new folders in `git status`; use `git status -u` to see every file.
- `git lfs ls-files` confirms which files are stored in LFS.

### 🐛 Problems
- Ground and ceiling didn't trigger Game Over → the collider component was disabled.
- `ScoreText` ended up inside the `EventSystem` object, which also had the `Canvas` → renamed it `UI`.
- Restart button did nothing → the Canvas was missing its **`Graphic Raycaster`**.
- "Traje de ardilla" meant a wingsuit, not a squirrel costume 😅
- Side-view reference didn't look right → kept the front view.
- Background and ambient images were ~1250–1774 px → redrew the backgrounds at 480×240 and downscaled the characters.
- Trees took three iterations (generic domes → individual trees → dense chunky forest).
- Looked for sorting layers in the wrong dropdown (Layer vs Sorting Layer).
- Thought ambient objects weren't destroyed → the Inspector showed local X; also added camera-based limits for both directions.

### ➡️ Next
- Review the trees.
- Decide the obstacles (pipes are still placeholders).
- Street lamps + day/night cycle.

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

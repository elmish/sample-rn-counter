# ReactNative counter sample

An [Elmish](https://elmish.github.io/elmish/) counter app running on React Native, using [Fable](https://fable.io/) to compile F# to JavaScript.

## Pre-requisites

1. [.NET SDK](https://dotnet.microsoft.com/download) (8.0+)
2. [Node.js](https://nodejs.org/) (>= 22.11.0)
3. React Native development environment set up for your target platform:
   - **iOS**: Xcode, Ruby 3.3, CocoaPods (>= 1.13)
   - **Android**: Android Studio, Android SDK

## Setup

```sh
npm install
dotnet tool restore
npm run setup        # regenerates ios/ and android/ from the RN 0.71 template and installs pods
```

`npm run setup` runs `scripts/setup-native.sh`, which scaffolds the native projects via `@react-native-community/cli`, overlays custom assets from `template/`, and runs `pod install`.

## Build & Run

1. `npm run watch` — starts Fable in watch mode, recompiling F# to JS on save
2. In a separate terminal: `npm run ios` or `npm run android`

All npm scripts are defined in `package.json`:

| Script | Command |
|--------|---------|
| `setup` | Regenerate native projects + pod install |
| `build` | One-shot Fable compile (release) |
| `watch` | Fable watch mode (debug) |
| `ios` | `react-native run-ios` |
| `android` | `react-native run-android` |
| `start` | Start Metro bundler |

## Tooling

| Tool | Version |
|------|---------|
| React Native | 0.71.19 |
| Fable | 4.29.0 (local tool via `dotnet-tools.json`) |
| Fable.Elmish | 5.0.2 |
| Fable.React.Native | 4.0.0 |

NuGet packages are referenced directly in `src/app.fsproj` (Paket is no longer used).

## Project structure

- `src/App.fs` — Elmish model, update, and view
- `src/Styles.fs` — React Native styles
- `src/app.fsproj` — F# project with NuGet package references
- `index.js` — React Native entry point (imports compiled Fable output from `out/`)
- `out/` — Fable-compiled JavaScript output (gitignored)
- `scripts/setup-native.sh` — regenerates native projects from the RN template
- `template/ios/` — custom iOS assets overlaid during setup

#!/usr/bin/env bash
set -euo pipefail

# Regenerate ios/ and android/ native projects from the RN template,
# then overlay custom assets from template/ and install pods.

APP_NAME="counter"
RN_VERSION="0.71.19"
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
TMPDIR_NATIVE="$(mktemp -d)"

cleanup() { rm -rf "$TMPDIR_NATIVE"; }
trap cleanup EXIT

echo "==> Generating RN $RN_VERSION native projects..."
npx --yes @react-native-community/cli@10 init "$APP_NAME" \
  --version "$RN_VERSION" \
  --skip-install \
  --directory "$TMPDIR_NATIVE/$APP_NAME" \
  > /dev/null 2>&1

echo "==> Replacing ios/ and android/..."
rm -rf "$ROOT/ios" "$ROOT/android"
cp -R "$TMPDIR_NATIVE/$APP_NAME/ios" "$ROOT/ios"
cp -R "$TMPDIR_NATIVE/$APP_NAME/android" "$ROOT/android"

# Overlay custom iOS assets (Info.plist, LaunchScreen, icons, etc.)
if [ -d "$ROOT/template/ios" ]; then
  echo "==> Applying custom iOS assets from template/..."
  cp -R "$ROOT/template/ios/" "$ROOT/ios/"
fi

echo "==> Installing pods..."
export PATH="/usr/local/opt/ruby-3.3/bin:${PATH}"
cd "$ROOT/ios" && pod install

echo "==> Done. Run 'npx react-native run-ios' or 'npx react-native run-android'."

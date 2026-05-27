# ScreenSaverLock

Windows 트레이 상주 화면 잠금 프로그램입니다.

## 기능

| 기능 | 설명 |
|------|------|
| 전역 단축키 | **Ctrl+M** — 어디서든 즉시 잠금 화면 진입 |
| 이미지 슬라이드쇼 | `이미지` 폴더의 이미지를 5초마다 순환 표시 |
| 비밀번호 잠금 | 비밀번호 입력 전까지 화면 해제 불가 |
| 절전 블랭크 | 잠금 상태에서 10초 무입력 시 화면 완전 블랙, 마우스/키 입력 시 복원 |
| 설정 GUI | 트레이 아이콘 더블클릭으로 설정 폼 표시 |
| 자동 실행 | 설정에서 Windows 시작 시 자동 실행 ON/OFF |
| 비밀번호 변경 | 설정 폼에서 현재 비밀번호 확인 후 변경 |
| 커스텀 아이콘 | 트레이 아이콘, 창 아이콘, EXE 파일 아이콘 모두 동일하게 적용 |

## 사용 방법

1. **ScreenSaverLock.exe** 실행 → 트레이에 아이콘 표시
2. **Ctrl+M** 을 누르면 즉시 잠금 화면으로 전환
3. 잠금 해제 시 비밀번호 입력 (기본: `0000`)
4. 트레이 아이콘 더블클릭 → 설정 GUI

## 슬라이드쇼 이미지 추가

실행 파일과 같은 위치의 `이미지` 폴더에 이미지를 넣으면 자동으로 슬라이드쇼에 포함됩니다.

- 지원 형식: `.jpg` `.jpeg` `.png` `.bmp` `.gif`
- 이미지가 없으면 기본 배경(`기본배경.png`)이 자동 생성됩니다.

## 설정 파일

- 저장 위치: `%APPDATA%\ScreenSaverLock\settings.json`
- 비밀번호는 SHA-256 해시로 저장됩니다.

## 빌드

```bash
# 디버그 빌드
dotnet build -c Debug

# Release 빌드 (단일 파일 자동 게시)
dotnet build -c Release
# → bin\Release\Publish\ScreenSaverLock.exe 생성
```

## 요구 사항

- Windows 10 / 11
- .NET 8.0 Runtime
"# ScreenSaverLock" 

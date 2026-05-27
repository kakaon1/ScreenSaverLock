# CLAUDE.md — 에이전트 작업 지침 문서

## 기본 정보

| 항목 | 내용 |
|------|------|
| 프로젝트명 | ScreenSaverLock |
| 운영체제 | Windows 11 Pro (64비트) |
| 사용 언어 | C# / .NET 8.0 (WinForms) |
| 문서 작성일 | 2026-05-26 |

---

## 프로젝트 개요

Windows 트레이 상주 화면 잠금 프로그램.

- **Ctrl+M** 전역 단축키로 즉시 잠금 화면 진입
- 잠금 화면에 `이미지` 폴더의 이미지 순차 슬라이드쇼 표시
- 비밀번호 입력으로만 해제 (기본: `0000`)
- 트레이 더블클릭으로 설정 GUI 폼 표시
- Windows 시작 시 자동 실행 기능 지원

---

## 프로젝트 구조

```
ScreenSaverLock/
├── ScreenSaverLock.csproj       # 빌드 설정 (Release 자동 게시 포함)
├── Program.cs                   # 진입점 — 단일 인스턴스 보장, 아이콘/이미지 생성
├── MainForm.cs                  # 백그라운드 폼 — 트레이 아이콘, Ctrl+M 단축키
├── MainForm.Designer.cs         # 디자이너 파일
├── LockForm.cs                  # 전체화면 잠금 화면 — 슬라이드쇼 + 비밀번호 입력
├── LockForm.Designer.cs         # 디자이너 파일
├── ControlForm.cs               # 설정 GUI 폼 — 자동 시작, 비밀번호 변경
├── ControlForm.Designer.cs      # 디자이너 파일
├── AppSettings.cs               # 설정 관리 (JSON, 비밀번호 SHA-256 해시)
├── NativeMethods.cs             # Windows API P/Invoke (전역 단축키, 유휴 시간)
├── ResourceHelper.cs            # 앱 아이콘 + 기본 배경 이미지 런타임 생성
│
├── 이미지/                      # 슬라이드쇼용 이미지 폴더 (실행 시 자동 생성)
│   └── 기본배경.png             # 이미지 없을 때 자동 생성되는 기본 배경
│
└── bin/Release/Publish/
    └── ScreenSaverLock.exe      # 단일 실행 파일 (Release 빌드 시 자동 생성)
```

---

## 빌드 설정 (4번 조항)

- .NET 8.0-windows / WinExe 타입
- Release 빌드 시 `bin\Release\Publish\` 에 단일 파일(.exe)로 자동 게시
- pdb 파일 미생성 (`<DebugType>None</DebugType>`)
- 빌드 후 자동 게시: `.csproj`의 `AutoPublish` 타겟이 `dotnet publish`를 자동 실행

---

## 실행 방법

### 개발 실행 (디버그)
```
dotnet build -c Debug
bin\Debug\net8.0-windows\ScreenSaverLock.exe 실행
```

### 배포 실행 (릴리스)
```
dotnet build -c Release
→ bin\Release\Publish\ScreenSaverLock.exe 자동 생성
```

---

## 환경 설정

| 항목 | 내용 |
|------|------|
| .NET 버전 | .NET 8.0 |
| 빌드 도구 | dotnet CLI 10.0.203 |
| Visual Studio | WinForms 디자이너 지원 (.Designer.cs 포함) |
| 설정 저장 위치 | `%APPDATA%\ScreenSaverLock\settings.json` |
| 기본 비밀번호 | `0000` |
| 이미지 폴더 | 실행 파일 경로 기준 `이미지\` 폴더 |

---

## 주요 기능 요약

| 기능 | 구현 방법 |
|------|----------|
| 전역 단축키 Ctrl+M | `RegisterHotKey` Win32 API |
| 잠금 화면 슬라이드쇼 | `이미지\` 폴더의 jpg/png/bmp/gif 5초 순환 |
| 비밀번호 검증 | SHA-256 해시 비교 |
| 자동 실행 | `HKCU\Software\Microsoft\Windows\CurrentVersion\Run` 레지스트리 |
| 앱 아이콘 | `ResourceHelper.CreateAppIcon()` — GDI+ 런타임 생성 |
| 기본 배경 이미지 | `ResourceHelper.EnsureDefaultImage()` — `이미지\기본배경.png` |

---

## 변경 이력

| 날짜 | 변경 내용 | 구분 |
|------|-----------|------|
| 2026-05-26 | 최초 문서 생성 | 추가 |
| 2026-05-26 | 워크스페이스 스캔 — OS: Windows 11 Pro 64비트 확인 | 수정 |
| 2026-05-26 | 사용 언어 확정: C# / .NET 8.0 WinForms | 수정 |
| 2026-05-26 | 신규 프로젝트 전체 구성 완료 | 추가 |
| 2026-05-26 | 디자이너 파일(.Designer.cs) 추가 — VS 디자이너 지원 | 추가 |
| 2026-05-26 | ResourceHelper 추가 — 앱 아이콘 및 기본 배경 이미지 자동 생성 | 추가 |
| 2026-05-26 | ControlForm 높이 계산 수정 (508→530) — 컨트롤 표시 범위 초과 버그 수정 | 수정 |
| 2026-05-26 | AppSettings.SetPassword 보안 버그 수정 — 빈 currentPassword 우회 방지 | 수정 |
| 2026-05-26 | app.ico 생성 및 .csproj ApplicationIcon 설정 — EXE 파일 아이콘 변경 | 추가 |
| 2026-05-26 | 10초 블랭크 기능 추가 — 무입력 시 화면 완전 블랙, 마우스/키 입력 시 복원 | 추가 |
| 2026-05-26 | 잠금 패널 위치 55% 수직으로 재배치, 배경 이미지 자물쇠 아이콘 30% 위치로 분리 | 수정 |
| 2026-05-26 | Cursors.None 제거 → Cursor.Hide()/Show() + _cursorHidden 플래그로 교체 | 수정 |
| 2026-05-26 | 비밀번호 입력창 포커스 문제 수정 — OnLoad→OnShown 이벤트 + BeginInvoke 적용 | 수정 |
| 2026-05-26 | 블랭크 미작동 버그 수정 — _lastMousePos 추적으로 합성 WM_MOUSEMOVE 필터링 | 수정 |
| 2026-05-26 | 블랭크 복원 후 입력 불가 버그 수정 — 복원 시 Activate() + 커서 재숨김 추가 | 수정 |
| 2026-05-26 | 잠금 해제 후 커서 미복원 버그 수정 — Cursor.Show()를 Dispose→OnFormClosed로 이전 | 수정 |
| 2026-05-26 | 커서 방식 전면 교체 — ShowCursor 참조카운트 제거, Win32 CreateCursor 투명커서 사용 | 수정 |
| 2026-05-26 | TryUnlock에서 커서 즉시 복원 추가 — SetDefaultCursorRecursive + Cursor.Current=Default | 수정 |
| 2026-05-26 | 커서 설계 확정 — 잠금화면 표시/블랭크 숨김/복원 (Cursor 프로퍼티, ShowCursor 미사용) | 수정 |
| 2026-05-26 | VS WinForms 디자이너 지원 전면 재작성 — 세 폼 모두 Designer.cs 분리, .csproj SubType/DependentUpon 추가 | 수정 |
| 2026-05-26 | LockScreenControls.cs 추가 — DoubleBufferedPanel·FlatButton을 internal 클래스로 분리 (VS 디자이너 인스턴스화 요건) | 추가 |
| 2026-05-26 | Designer.cs 파싱 오류 수정 — 로컬 변수·람다·중첩 클래스 제거, 필드 선언 #endregion 이후로 이동 | 수정 |
| 2026-05-26 | backup\ 폴더 .csproj 제외 처리 — MSB3577 중복 EmbeddedResource 오류 해결 | 수정 |
| 2026-05-26 | 잠금 패널 수직 위치 0.55f 확정, 시간 레이블 높이 90px으로 확보 (52pt 폰트 DPI 잘림 방지) | 수정 |

# CODEMAP.md — 빌드 오류 이력

---

## 오류 #1

```
오류 발생일: 2026-05-26
발생 단계:  4. 주요 처리 단계 (LockForm 초기 빌드)
오류 내용:  CS0117 — 'FontStyle'에는 'Light'에 대한 정의가 포함되어 있지 않습니다.
원인 분석:  System.Drawing.FontStyle 열거형에는 Bold / Italic / Regular /
             Strikeout / Underline 만 존재. 'Light'는 WPF(Windows.Media)에서만 지원.
조치 내용:  LockForm.cs의 MakeLabel 호출부에서
             FontStyle.Light → FontStyle.Regular 로 수정.
재발 방지:  WinForms에서는 FontStyle.Light 대신 폰트 패밀리명에
             "Segoe UI Light"를 사용하거나 FontStyle.Regular를 사용한다.
```

---

## 오류 #2 (경고 → 수정)

```
오류 발생일: 2026-05-26
발생 단계:  4. 주요 처리 단계 (MainForm 트레이 메뉴 구성)
오류 내용:  CS8604 — SystemFonts.MenuFont는 nullable이므로 null 참조 경고 발생.
원인 분석:  SystemFonts.MenuFont 반환값이 nullable(Font?)로 선언되어 있음.
조치 내용:  new Font(SystemFonts.MenuFont, FontStyle.Bold)
               → new Font(SystemFonts.MenuFont ?? SystemFonts.DefaultFont, FontStyle.Bold)
재발 방지:  SystemFonts의 속성은 항상 null 가능성을 체크하고 대체 폰트를 제공한다.
```

---

## 버그 #3 (런타임 버그 — 보안)

```
오류 발생일: 2026-05-26
발생 단계:  6. 정책 적용 (비밀번호 변경 검증)
오류 내용:  AppSettings.SetPassword에서 currentPassword가 빈 문자열일 때
             VerifyPassword 검증을 건너뛰는 로직 존재.
원인 분석:  if (!string.IsNullOrEmpty(currentPassword) && !VerifyPassword(currentPassword))
             → currentPassword == "" 이면 IsNullOrEmpty가 true 반환,
               단락(&&) 평가로 VerifyPassword가 실행되지 않아 인증 우회 가능.
조치 내용:  조건을 if (!VerifyPassword(currentPassword)) 로 단순화하여
             빈 문자열도 반드시 해시 검증을 통과해야 변경 허용.
재발 방지:  인증 우회 가능성이 있는 단락 조건은 사용하지 않는다.
             비밀번호 검증은 항상 VerifyPassword()를 직접 호출한다.
```

---

## 버그 #4 (레이아웃)

```
오류 발생일: 2026-05-26
발생 단계:  4. 주요 처리 단계 (ControlForm 레이아웃 계산)
오류 내용:  ControlForm ClientSize(430, 508)로 설정 시
             btnExit 하단이 ~520px으로 클라이언트 영역을 초과함.
원인 분석:  레이아웃 y 값 누적 계산 오류 — 실제 필요 높이를 과소 산정.
조치 내용:  ClientSize → (430, 530) 으로 조정.
재발 방지:  폼 레이아웃 작성 시 y 값을 수동으로 누적 계산하여 검증한다.
```

---

## 오류 #5

```
오류 발생일: 2026-05-26
발생 단계:  5. 디자이너 파일 추가 후 빌드
오류 내용:  CS0111 — 'LockForm'에서 동일한 매개변수 형식을 갖는 형식 멤버
             'InitializeComponent'가 이미 정의되어 있습니다.
원인 분석:  LockForm.cs에 이미 정의된 private void InitializeComponent() { }가
             LockForm.Designer.cs의 동일 메서드와 중복되어 충돌 발생.
조치 내용:  LockForm.cs에서 private void InitializeComponent() { } 제거.
             Designer.cs에만 InitializeComponent 메서드 유지.
재발 방지:  Designer.cs를 추가할 때는 원본 .cs 파일에 InitializeComponent가
             있으면 반드시 제거한다.
```

---

## 오류 #6

```
오류 발생일: 2026-05-26
발생 단계:  4. 주요 처리 단계 (LockForm 커서 숨김 구현)
오류 내용:  CS0117 — 'Cursors'에는 'None'에 대한 정의가 포함되어 있지 않습니다.
원인 분석:  WinForms System.Windows.Forms.Cursors에는 None 멤버가 없음.
             커서 숨김은 Cursor.Hide() / Cursor.Show() 정적 메서드로만 처리 가능.
조치 내용:  Cursor = Cursors.None 제거, _cursorHidden bool 필드 추가.
             OnShown 이벤트에서 Cursor.Hide() 호출 (폼이 완전히 표시된 후),
             Dispose(bool)에서 Cursor.Show() 호출 (커서 복원 보장).
재발 방지:  WinForms에서 커서를 완전히 숨기려면 Cursor.Hide()를 사용하고,
             _cursorHidden 플래그로 Show/Hide 쌍을 정확히 맞춘다.
```

---

## 버그 #7 (런타임 버그 — 블랭크 미작동)

```
오류 발생일: 2026-05-26
발생 단계:  런타임 테스트 (10초 블랭크 기능)
오류 내용:  10초가 지나도 블랭크 상태가 되지 않음.
원인 분석:  Windows OS는 창 활성화나 컨트롤 갱신 시 실제 마우스 이동 없이도
             합성 WM_MOUSEMOVE를 지속적으로 전송함.
             OnUserActivity가 이 합성 이벤트에 반응하여 _blankTimer를 계속
             리셋하므로 타이머가 만료되지 못했음.
조치 내용:  _lastMousePos 필드(초기값 int.MinValue) 추가.
             OnUserActivity에서 MouseEventArgs인 경우에만 Cursor.Position을 체크,
             실제 위치가 바뀌지 않으면 early return하여 타이머를 리셋하지 않음.
재발 방지:  MouseMove 이벤트 핸들러에서는 항상 실제 커서 위치 변화를 확인한 후
             처리 로직을 실행한다.
```

---

## 버그 #9 (런타임 버그 — 잠금 해제 후 마우스 커서 미복원)

```
오류 발생일: 2026-05-26
발생 단계:  런타임 테스트 (잠금 해제 후 데스크탑)
오류 내용:  올바른 비밀번호로 잠금 해제 후 데스크탑에서 마우스 커서가 보이지 않음.
원인 분석:  LockForm은 MainForm에서 Show()로 비모달 표시됨.
             비모달 폼에서 Close() 호출 시 FormClosed 이벤트는 발생하지만
             Dispose(bool)가 즉시 호출된다는 보장이 없음.
             Cursor.Show()가 Dispose(bool)에만 있어 실행되지 못하는 경우 발생.
조치 내용:  [최종] 커서 설계 확정.
             - 잠금 화면 일반 상태: 커서 표시 (UI 조작 필요)
             - 블랭크 상태(검은 화면): 커서 숨김 (Win32 CreateCursor 투명 커서)
             - 블랭크 해제 시: Cursor = Cursors.Default 로 즉시 복원
             블랭크 중에는 모든 컨트롤이 숨겨져 폼 배경만 노출되므로
             this.Cursor 변경만으로 충분 (ShowCursor 사용 안 함).
재발 방지:  커서 숨김은 블랭크 상태에만 적용한다.
             ShowCursor 참조 카운트 방식 대신 Cursor 프로퍼티로 관리한다.
```

---

## 버그 #8 (런타임 버그 — 블랭크 복원 후 입력 불가)

```
오류 발생일: 2026-05-26
발생 단계:  런타임 테스트 (블랭크 복원 후 비밀번호 입력)
오류 내용:  블랭크에서 마우스를 흔들어 복원하면 커서와 입력이 정상 동작하지 않음.
원인 분석:  블랭크 복원 시 BeginInvoke에서 _txtPassword.Focus()만 호출하고
             Activate()를 누락하여 폼이 비활성 상태로 남았음.
             또한 컨트롤 재표시 시 OS가 커서 상태를 변경할 수 있어
             _cursorHidden 플래그와 실제 커서 상태가 불일치할 수 있었음.
조치 내용:  복원 시 BeginInvoke(() => { Activate(); _txtPassword.Focus(); }) 로 변경.
             복원 시 !_cursorHidden 조건으로 Cursor.Hide() 재호출 보장.
재발 방지:  잠금 폼 복원 흐름에서는 항상 Activate() → Focus() 순서로 호출하고
             커서 숨김 상태를 플래그로 재확인한다.
```

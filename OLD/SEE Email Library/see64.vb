Module see64
'
' SEE64.VB [SEE4VB Ver 5.1.1 for VB.Net]
'

Declare Function seeAbort Lib "SEE64.DLL" (ByVal Chan As Integer) As Integer
Declare Function seeAttach Lib "SEE64.DLL" (ByVal NbrChans As Integer, ByVal KeyCode As Integer) As Integer
Declare Function seeClose Lib "SEE64.DLL" (ByVal Chan As Integer) As Integer
Declare Function seeCommand Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Text As String) As Integer
Declare Function seeDebug Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Index As Integer, ByVal Buffer As String, ByVal BufLen As Integer) As Integer
Declare Function seeDecodeBuffer Lib "SEE64.DLL" (ByVal CodedBuf As String, ByVal ClearBuf As String, ByVal BufLen As Integer) As Integer
Declare Function seeDecodeUTF8 Lib "SEE64.DLL" (ByVal UTF8Buffer As String, ByVal UnicodeBuffer As String) As Integer
Declare Function seeDecodeUU Lib "SEE64.DLL" (ByVal CodedBuf As String, ByVal ClearBuf As String) As Integer
Declare Function seeDeleteEmail Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal MsgNbr As Integer) As Integer
Declare Function seeDriver Lib "SEE64.DLL" (ByVal Chan As Integer) As Integer
Declare Function seeEncodeBuffer Lib "SEE64.DLL" (ByVal ClearBuf As String, ByVal CodedBuf As String, ByVal BufLen As Integer) As Integer
Declare Function seeEncodeUTF8 Lib "SEE64.DLL" (ByVal UnicodeValue As Integer, ByVal UTF8Buffer As String) As Integer
Declare Function seeErrorText Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Code As Integer, ByVal Buffer As String, ByVal BufLen As Integer) As Integer
Declare Function seeExtractLine Lib "SEE64.DLL" (ByVal Src As String, ByVal LineNbr As Integer, ByVal Buffer As String, ByVal BufLen As Integer) As Integer
Declare Function seeExtractText Lib "SEE64.DLL" (ByVal Src As String, ByVal Text As String, ByVal Buffer As String, ByVal BufLen As Integer) As Integer
Declare Function seeForwardEmail Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Rcpt As String, ByVal CC As String, ByVal BCC As String, ByVal Subj As String, ByVal Msg As String, ByVal Forward As String) As Integer
Declare Function seeGetEmailCount Lib "SEE64.DLL" (ByVal Chan As Integer) As Integer
Declare Function seeGetEmailFile Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal MsgNbr As Integer, ByVal FileName As String, ByVal EmailDir As String, ByVal AttachDir As String) As Integer
Declare Function seeGetEmailLines Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal MsgNbr As Integer, ByVal Lines As Integer, ByVal Buffer As String, ByVal BufLen As Integer) As Integer
Declare Function seeGetEmailSize Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal MsgNbr As Integer) As Integer
Declare Function seeGetEmailUID Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal MsgNbr As Integer, ByVal Buffer As String, ByVal BufLen As Integer) As Integer
Declare Function seeIntegerParam Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Index As Integer, ByVal Value As Integer) As Integer
Declare Function seePop3Connect Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Server As String, ByVal User As String, ByVal Password As String) As Integer
Declare Function seePop3Source Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Filename As String) As Integer 
Declare Function seeQuoteBuffer Lib "SEE64.DLL" (ByVal ClearBuf As String, ByVal CodedBuf As String, ByVal BufLen As Integer) As Integer
Declare Function seeRelease Lib "SEE64.DLL" () As Integer
Declare Function seeSendEmail Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Rcpt As String, ByVal CC As String, ByVal BCC As String, ByVal Subj As String, ByVal Msg As String, ByVal Attach As String) As Integer
Declare Function seeSendHTML Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Rcpt As String, ByVal CC As String, ByVal BCC As String, ByVal Subj As String, ByVal Msg As String, ByVal Images As String, ByVal AltTxt As String, ByVal Attach As String) As Integer
Declare Function seeSmtpConnect Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Server As String, ByVal From As String, ByVal Reply As String) As Integer
Declare Function seeStatistics Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Index As Integer) As Integer
Declare Function seeStringParam Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Index As Integer, ByVal Value As String) As Integer
Declare Function seeVerifyFormat Lib "SEE64.DLL" (ByVal EmailAddr As String) As Integer
Declare Function seeVerifyUser Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal EmailAddr As String) As Integer
Declare Function seeAttachmentParams  Lib "SEE64.DLL" (ByVal ContentType As String,ByVal XferEncoding As String,ByVal Disposition As String,ByVal Description As String) As Integer
Declare Function seeImapConnect Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Pop3Ptr As String, ByVal UserPtr As String, ByVal PassPtr As String) As Integer
Declare Function seeImapFlags Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal MsgNbr As Integer, ByVal Command As Integer, ByVal FlagsMask As Integer) As Integer
Declare Function seeImapSearch Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal SearchArgs As String, ByVal Buffer As String, ByVal BufLen As Integer) As Integer        
Declare Function seeImapMsgNumber Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Command As Integer) As Integer
Declare Function seeImapSelectMB Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Mailbox As String) As Integer
Declare Function seeImapDeleteMB Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Mailbox As String) As Integer
Declare Function seeImapCreateMB Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Mailbox As String) As Integer
Declare Function seeImapRenameMB Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal FromName As String, ByVal ToName As String) As Integer
Declare Function seeImapCopyMBmail Lib "SEE64.DLL" (ByVal Chan As Integer,ByVal Message As Integer, ByVal Mailbox As String) As Integer
Declare Function seeImapListMB Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Buffer As String, ByVal BufLen As Integer) As Integer
Declare Function seeSetErrorText Lib "SEE64.DLL" (ByVal ErrCode As Integer, ByVal ErrText As String) As Integer
Declare Function seeSmtpTarget Lib "SEE64.DLL" (ByVal Chan As Integer, ByVal Filename As String, ByVal FromPtr As String, ByVal ReplyTo As String) As Integer
Declare Function seeStartProgram Lib "SEE64.DLL" (ByVal CmdLineb As String) As Integer
Declare Function seeKillProgram Lib "SEE64.DLL" (ByVal hProcess As Integer, ByVal ExitCode As Integer) As Integer
Declare Function seeSleep Lib "SEE64.DLL" (ByVal MilliSeconds As Integer) As Integer

Public Const SEE_MIN_RESPONSE_WAIT As Integer = 1
Public Const SEE_MAX_RESPONSE_WAIT As Integer = 2
Public Const SEE_CONNECT_WAIT As Integer = 3
Public Const SEE_DISABLE_MIME As Integer = 4
Public Const SEE_QUOTED_PRINTABLE As Integer = 8
Public Const SEE_AUTO_CALL_DRIVER As Integer = 9
Public Const SEE_FILE_PREFIX As Integer = 10
Public Const SEE_SLEEP_TIME As Integer = 13
Public Const SEE_DECODE_UNNAMED As Integer = 14
Public Const SEE_SMTP_PORT As Integer = 15
Public Const SEE_POP3_PORT As Integer = 16
Public Const SEE_MAX_LINE_LENGTH As Integer = 17
Public Const SEE_BLOCKING_MODE As Integer = 18
Public Const SEE_ALLOW_8BITS As Integer = 19
Public Const SEE_LOG_FILE As Integer = 20
Public Const SEE_HIDE_SAVED_MSG As Integer = 21
Public Const SEE_HIDE_TO_ADDR As Integer = 22
Public Const SEE_ADDRESS_DELIMITER As Integer = 23
Public Const SEE_WSACLEANUP As Integer = 24
Public Const SEE_PATH_DELIMITER As Integer = 25
Public Const SEE_ATTACH_DELIMITER  As Integer = 26
Public Const SEE_ENABLE_IMAGE As Integer = 27
Public Const SEE_RAW_MODE As Integer = 28
Public Const SEE_ENABLE_ESMTP As Integer = 29
Public Const SEE_ENABLE_APOP As Integer = 30
Public Const SEE_ATTACH_BASE_NUMBER As Integer = 31
Public Const SEE_IGNORE_REJECTED As Integer = 32
Public Const SEE_WRITE_CONTENT_TYPE As Integer = 33
Public Const SEE_SET_FILE_PREFIX As Integer = 34
Public Const SEE_HTML_CHARSET As Integer = 35
Public Const SEE_HIDE_HEADERS As Integer = 36
Public Const SEE_KEEP_RFC822_INTACT As Integer = 37
Public Const SEE_IMAP_PORT As Integer = 38
Public Const SEE_EXPUNGE_ON_CLOSE As Integer = 39

Public Const CHARSET_BLANK As Integer = 0
Public Const CHARSET_US_ASCII As Integer = 1
Public Const CHARSET_8859 As Integer = 4
Public Const CHARSET_ISO_8859_1 As Integer = 4
Public Const CHARSET_ISO_8859_8 As Integer = 5
Public Const CHARSET_WIN_1252 As Integer = 6
Public Const CHARSET_WIN_1255 As Integer = 7
 
Public Const IMAP_FLAG_SEEN As Integer = 1
Public Const IMAP_FLAG_ANSWERED As Integer = 2
Public Const IMAP_FLAG_FLAGGED As Integer = 4
Public Const IMAP_FLAG_DELETED As Integer = 8
Public Const IMAP_FLAG_DRAFT As Integer = 16
Public Const IMAP_FLAG_RECENT As Integer = 32

Public Const IMAP_GET_FLAGS As Integer = 1
Public Const IMAP_SET_FLAGS As Integer = 2
Public Const IMAP_DEL_FLAGS As Integer = 3

Public Const IMAP_SEARCH_MSG_COUNT As Integer = 1
Public Const IMAP_SEARCH_FIRST_MSG As Integer = 2
Public Const IMAP_SEARCH_NEXT_MSG  As Integer = 3

Public Const SEE_GET_ERROR_TEXT As Integer = 1
Public Const SEE_GET_COUNTER As Integer = 2
Public Const SEE_GET_RESPONSE As Integer = 3
Public Const SEE_GET_SOCK_ERROR As Integer = 4
Public Const SEE_GET_MESSAGE_BYTES_READ As Integer = 10
Public Const SEE_GET_ATTACH_BYTES_READ As Integer = 11
Public Const SEE_GET_TOTAL_BYTES_READ As Integer = 12
Public Const SEE_GET_MESSAGE_BYTES_SENT As Integer = 13
Public Const SEE_GET_ATTACH_BYTES_SENT As Integer = 14
Public Const SEE_GET_TOTAL_BYTES_SENT As Integer = 15
Public Const SEE_GET_VERSION As Integer = 16
Public Const SEE_GET_MSG_COUNT As Integer = 17
Public Const SEE_GET_MSG_SIZE As Integer = 18
Public Const SEE_GET_BUFFER_COUNT As Integer = 19
Public Const SEE_GET_CONNECT_STATUS As Integer = 20
Public Const SEE_GET_REGISTRATION As Integer = 21
Public Const SEE_GET_ATTACH_COUNT As Integer = 22
Public Const SEE_GET_LAST_RESPONSE As Integer = 23
Public Const SEE_GET_VERIFY_STATUS As Integer = 24
Public Const SEE_GET_SERVER_IP As Integer = 25
Public Const SEE_GET_BUILD As Integer = 26
Public Const SEE_GET_SOCKET As Integer = 27
Public Const SEE_GET_LOCAL_IP As Integer = 28
Public Const SEE_GET_ATTACH_NAMES As Integer = 29
Public Const SEE_GET_LAST_RECIPIENT As Integer = 30
Public Const SEE_GET_AUTH_PROTOCOLS As Integer = 31
Public Const SEE_GET_ATTACH_TYPES As Integer = 32
Public Const SEE_GET_ATTACH_IDS As Integer = 33

Public Const SEE_COPY_BUFFER As Integer = 40
Public Const SEE_WRITE_BUFFER As Integer = 41

Public Const SEE_SET_REPLY As Integer = 50
Public Const SEE_SET_HEADER As Integer = 51
Public Const SEE_WRITE_TO_LOG As Integer = 52
Public Const SEE_SET_FROM As Integer = 53
Public Const SEE_SET_CONTENT_TYPE As Integer = 54
Public Const SEE_SET_TRANSFER_ENCODING As Integer = 55
Public Const SEE_ADD_HEADER As Integer = 56
Public Const SEE_SET_SECRET As Integer = 57
Public Const SEE_SET_USER As Integer = 58
Public Const SEE_SET_TEXT_MESSAGE As Integer = 59
Public Const SEE_FORCE_INLINE As Integer = 60
Public Const SEE_SET_ATTACH_CONTENT_TYPE As Integer = 61
Public Const SEE_AUTHENTICATE_PROTOCOL As Integer = 62
Public Const SEE_SET_CONTENT_TYPE_PREFIX As Integer = 63
Public Const SEE_ENABLE_XMAILER As Integer = 64
Public Const SEE_SET_DEFAULT_ZONE As Integer = 65
Public Const SEE_SET_ATTACH_DESCRIPTION As Integer = 66
Public Const SEE_REPLACE_WITH_COMMAS As Integer = 67
Public Const SEE_SET_MULTIPART As Integer = 68
Public Const SEE_SET_TIME_ZONE As Integer = 69
Public Const SEE_SET_RAWFILE_PREFIX As Integer = 70

Public Const QUOTED_OFF        As Integer = 0
Public Const QUOTED_PLAIN      As Integer = 1
Public Const QUOTED_HTML       As Integer = 2
Public Const QUOTED_RICH       As Integer = 3
Public Const QUOTED_8859       As Integer = 4
Public Const QUOTED_ISO_8859_1 As Integer = 4
Public Const QUOTED_ISO_8859_8 As Integer = 5
Public Const QUOTED_WIN_1252   As Integer = 6
Public Const QUOTED_WIN_1255   As Integer = 7
Public Const QUOTED_USER       As Integer = 9

Public Const INLINE_TEXT_OFF        As Integer = 0
Public Const INLINE_TEXT_INLINE     As Integer = 1
Public Const INLINE_TEXT_ATTACHMENT As Integer = 2

Public Const AUTHENTICATE_CRAM  As Integer = 1
Public Const AUTHENTICATE_LOGIN As Integer = 2
Public Const AUTHENTICATE_PLAIN As Integer = 4

End Module

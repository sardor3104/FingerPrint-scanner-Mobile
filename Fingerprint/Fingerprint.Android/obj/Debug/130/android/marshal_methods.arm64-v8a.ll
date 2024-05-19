; ModuleID = 'obj\Debug\130\android\marshal_methods.arm64-v8a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [214 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 53
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 16
	i64 210515253464952879, ; 2: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 43
	i64 232391251801502327, ; 3: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 75
	i64 295915112840604065, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 76
	i64 634308326490598313, ; 5: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 62
	i64 702024105029695270, ; 6: System.Drawing.Common => 0x9be17343c0e7726 => 95
	i64 720058930071658100, ; 7: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 56
	i64 872800313462103108, ; 8: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 52
	i64 940822596282819491, ; 9: System.Transactions => 0xd0e792aa81923a3 => 93
	i64 996343623809489702, ; 10: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 88
	i64 1000557547492888992, ; 11: Mono.Security.dll => 0xde2b1c9cba651a0 => 105
	i64 1120440138749646132, ; 12: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 90
	i64 1315114680217950157, ; 13: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 37
	i64 1425944114962822056, ; 14: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 3
	i64 1624659445732251991, ; 15: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 35
	i64 1628611045998245443, ; 16: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 64
	i64 1636321030536304333, ; 17: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 57
	i64 1731380447121279447, ; 18: Newtonsoft.Json => 0x18071957e9b889d7 => 18
	i64 1743969030606105336, ; 19: System.Memory.dll => 0x1833d297e88f2af8 => 106
	i64 1795316252682057001, ; 20: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 36
	i64 1836611346387731153, ; 21: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 75
	i64 1865037103900624886, ; 22: Microsoft.Bcl.AsyncInterfaces => 0x19e1f15d56eb87f6 => 15
	i64 1875917498431009007, ; 23: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 33
	i64 1981742497975770890, ; 24: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 63
	i64 2040001226662520565, ; 25: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 104
	i64 2133195048986300728, ; 26: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 18
	i64 2136356949452311481, ; 27: Xamarin.AndroidX.MultiDex.dll => 0x1da5dd539d8acbb9 => 68
	i64 2164418022825914083, ; 28: Fingerprint.Android.dll => 0x1e098eb963fdeee3 => 0
	i64 2165725771938924357, ; 29: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 41
	i64 2262844636196693701, ; 30: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 52
	i64 2284400282711631002, ; 31: System.Web.Services => 0x1fb3d1f42fd4249a => 99
	i64 2329709569556905518, ; 32: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 60
	i64 2335503487726329082, ; 33: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 28
	i64 2337758774805907496, ; 34: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 26
	i64 2367203355387446297, ; 35: MailCheck.dll => 0x20d9fee8e4fb4419 => 14
	i64 2470498323731680442, ; 36: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 47
	i64 2479423007379663237, ; 37: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 80
	i64 2497223385847772520, ; 38: System.Runtime => 0x22a7eb7046413568 => 27
	i64 2547086958574651984, ; 39: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 32
	i64 2592350477072141967, ; 40: System.Xml.dll => 0x23f9e10627330e8f => 30
	i64 2624866290265602282, ; 41: mscorlib.dll => 0x246d65fbde2db8ea => 17
	i64 2694427813909235223, ; 42: Xamarin.AndroidX.Preference.dll => 0x256487d230fe0617 => 72
	i64 2783046991838674048, ; 43: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 26
	i64 2812926542227278819, ; 44: Google.Apis.Core.dll => 0x270985c960b98be3 => 11
	i64 2960931600190307745, ; 45: Xamarin.Forms.Core => 0x2917579a49927da1 => 86
	i64 3017704767998173186, ; 46: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 90
	i64 3289520064315143713, ; 47: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 59
	i64 3303437397778967116, ; 48: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 34
	i64 3311221304742556517, ; 49: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 25
	i64 3493805808809882663, ; 50: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 78
	i64 3522470458906976663, ; 51: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 77
	i64 3531994851595924923, ; 52: System.Numerics => 0x31042a9aade235bb => 24
	i64 3571415421602489686, ; 53: System.Runtime.dll => 0x319037675df7e556 => 27
	i64 3716579019761409177, ; 54: netstandard.dll => 0x3393f0ed5c8c5c99 => 1
	i64 3727469159507183293, ; 55: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 74
	i64 3772598417116884899, ; 56: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 53
	i64 3966267475168208030, ; 57: System.Memory => 0x370b03412596249e => 106
	i64 4326933140005261798, ; 58: Xamarin.AndroidX.Biometric => 0x3c0c5ac408e111e6 => 40
	i64 4525561845656915374, ; 59: System.ServiceModel.Internals => 0x3ece06856b710dae => 100
	i64 4585851997256629731, ; 60: EntryCustomReturn.Forms.Plugin.Abstractions => 0x3fa4381838ff3de3 => 5
	i64 4636684751163556186, ; 61: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 82
	i64 4782108999019072045, ; 62: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 39
	i64 4794310189461587505, ; 63: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 32
	i64 4795410492532947900, ; 64: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 77
	i64 5142919913060024034, ; 65: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 87
	i64 5203618020066742981, ; 66: Xamarin.Essentials => 0x4836f704f0e652c5 => 85
	i64 5205316157927637098, ; 67: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 66
	i64 5348796042099802469, ; 68: Xamarin.AndroidX.Media => 0x4a3abda9415fc165 => 67
	i64 5376510917114486089, ; 69: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 80
	i64 5408338804355907810, ; 70: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 79
	i64 5451019430259338467, ; 71: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 46
	i64 5507995362134886206, ; 72: System.Core.dll => 0x4c705499688c873e => 22
	i64 5665389054145784248, ; 73: Google.Apis.Core => 0x4e9f815406bee9b8 => 11
	i64 5692067934154308417, ; 74: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 84
	i64 5757522595884336624, ; 75: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 44
	i64 5814345312393086621, ; 76: Xamarin.AndroidX.Preference => 0x50b0b44182a5c69d => 72
	i64 5896680224035167651, ; 77: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 61
	i64 5974002045223400615, ; 78: Plugin.Fingerprint => 0x52e7eb3560ff74a7 => 19
	i64 6085203216496545422, ; 79: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 88
	i64 6086316965293125504, ; 80: FormsViewGroup.dll => 0x5476f10882baef80 => 9
	i64 6222399776351216807, ; 81: System.Text.Json.dll => 0x565a67a0ffe264a7 => 29
	i64 6319713645133255417, ; 82: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 62
	i64 6345785522429471914, ; 83: Fingerprint => 0x5810c24fad39acaa => 7
	i64 6401687960814735282, ; 84: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 60
	i64 6504860066809920875, ; 85: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 41
	i64 6548213210057960872, ; 86: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 50
	i64 6591024623626361694, ; 87: System.Web.Services.dll => 0x5b7805f9751a1b5e => 99
	i64 6659513131007730089, ; 88: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 56
	i64 6876862101832370452, ; 89: System.Xml.Linq => 0x5f6f85a57d108914 => 31
	i64 6894844156784520562, ; 90: System.Numerics.Vectors => 0x5faf683aead1ad72 => 25
	i64 7036436454368433159, ; 91: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x61a671acb33d5407 => 58
	i64 7103753931438454322, ; 92: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 55
	i64 7270811800166795866, ; 93: System.Linq => 0x64e71ccf51a90a5a => 103
	i64 7488575175965059935, ; 94: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 31
	i64 7489048572193775167, ; 95: System.ObjectModel => 0x67ee71ff6b419e3f => 101
	i64 7635363394907363464, ; 96: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 86
	i64 7637365915383206639, ; 97: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 85
	i64 7654504624184590948, ; 98: System.Net.Http => 0x6a3a4366801b8264 => 2
	i64 7788888915696655788, ; 99: EntryCustomReturn.Forms.Plugin.Android.dll => 0x6c17b13397139dac => 6
	i64 7820441508502274321, ; 100: System.Data => 0x6c87ca1e14ff8111 => 92
	i64 7836164640616011524, ; 101: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 35
	i64 8044118961405839122, ; 102: System.ComponentModel.Composition => 0x6fa2739369944712 => 98
	i64 8064050204834738623, ; 103: System.Collections.dll => 0x6fe942efa61731bf => 102
	i64 8083354569033831015, ; 104: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 59
	i64 8103644804370223335, ; 105: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 94
	i64 8167236081217502503, ; 106: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 13
	i64 8185542183669246576, ; 107: System.Collections => 0x7198e33f4794aa70 => 102
	i64 8257259941817043446, ; 108: EntryCustomReturn.Forms.Plugin.Android => 0x7297ae2b121149f6 => 6
	i64 8392090689650705173, ; 109: EntryCustomReturn.Forms.Plugin.Abstractions.dll => 0x7476b204df7e4315 => 5
	i64 8398329775253868912, ; 110: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 45
	i64 8400357532724379117, ; 111: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 71
	i64 8601935802264776013, ; 112: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 79
	i64 8626175481042262068, ; 113: Java.Interop => 0x77b654e585b55834 => 13
	i64 8639588376636138208, ; 114: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 70
	i64 8684531736582871431, ; 115: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 97
	i64 9286073997824813334, ; 116: BouncyCastle.Cryptography => 0x80dec319ee56e916 => 4
	i64 9312692141327339315, ; 117: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 84
	i64 9324707631942237306, ; 118: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 36
	i64 9662334977499516867, ; 119: System.Numerics.dll => 0x8617827802b0cfc3 => 24
	i64 9678050649315576968, ; 120: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 47
	i64 9711637524876806384, ; 121: Xamarin.AndroidX.Media.dll => 0x86c6aadfd9a2c8f0 => 67
	i64 9808709177481450983, ; 122: Mono.Android.dll => 0x881f890734e555e7 => 16
	i64 9825649861376906464, ; 123: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 44
	i64 9834056768316610435, ; 124: System.Transactions.dll => 0x8879968718899783 => 93
	i64 9998632235833408227, ; 125: Mono.Security => 0x8ac2470b209ebae3 => 105
	i64 10038780035334861115, ; 126: System.Net.Http.dll => 0x8b50e941206af13b => 2
	i64 10229024438826829339, ; 127: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 50
	i64 10318047534812931528, ; 128: Xamarin.AndroidX.Biometric.dll => 0x8f311190c81ea5c8 => 40
	i64 10376576884623852283, ; 129: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 78
	i64 10430153318873392755, ; 130: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 48
	i64 10447083246144586668, ; 131: Microsoft.Bcl.AsyncInterfaces.dll => 0x90fb7edc816203ac => 15
	i64 10847732767863316357, ; 132: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 37
	i64 11023048688141570732, ; 133: System.Core => 0x98f9bc61168392ac => 22
	i64 11037814507248023548, ; 134: System.Xml => 0x992e31d0412bf7fc => 30
	i64 11162124722117608902, ; 135: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 83
	i64 11185638665393463709, ; 136: FingerprintPro.ServerSdk.dll => 0x9b3b5f1a24a6e19d => 8
	i64 11340910727871153756, ; 137: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 49
	i64 11392833485892708388, ; 138: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 73
	i64 11524545483990861064, ; 139: Fingerprint.Android => 0x9fef690edb1b8508 => 0
	i64 11529969570048099689, ; 140: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 83
	i64 11578238080964724296, ; 141: Xamarin.AndroidX.Legacy.Support.V4 => 0xa0ae2a30c4cd8648 => 58
	i64 11580057168383206117, ; 142: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 33
	i64 11597940890313164233, ; 143: netstandard => 0xa0f429ca8d1805c9 => 1
	i64 11672361001936329215, ; 144: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 55
	i64 12102847907131387746, ; 145: System.Buffers => 0xa7f5f40c43256f62 => 21
	i64 12137774235383566651, ; 146: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 81
	i64 12145679461940342714, ; 147: System.Text.Json => 0xa88e1f1ebcb62fba => 29
	i64 12437742355241350664, ; 148: Google.Apis.dll => 0xac9bbcc62bfdb608 => 12
	i64 12451044538927396471, ; 149: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 54
	i64 12466513435562512481, ; 150: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 65
	i64 12487638416075308985, ; 151: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 51
	i64 12512453786512196850, ; 152: Fingerprint.dll => 0xada52a6ccd8d04f2 => 7
	i64 12538491095302438457, ; 153: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 42
	i64 12550732019250633519, ; 154: System.IO.Compression => 0xae2d28465e8e1b2f => 96
	i64 12700543734426720211, ; 155: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 43
	i64 12958614573187252691, ; 156: Google.Apis => 0xb3d63f4bf006c1d3 => 12
	i64 12963446364377008305, ; 157: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 95
	i64 13168228444995699233, ; 158: MailCheck => 0xb6bef200a129c221 => 14
	i64 13370592475155966277, ; 159: System.Runtime.Serialization => 0xb98de304062ea945 => 3
	i64 13401370062847626945, ; 160: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 81
	i64 13404347523447273790, ; 161: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 45
	i64 13454009404024712428, ; 162: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 91
	i64 13491513212026656886, ; 163: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 38
	i64 13499576409650516429, ; 164: FingerprintPro.ServerSdk => 0xbb582138837651cd => 8
	i64 13572454107664307259, ; 165: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 74
	i64 13647894001087880694, ; 166: System.Data.dll => 0xbd670f48cb071df6 => 92
	i64 13959074834287824816, ; 167: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 54
	i64 13967638549803255703, ; 168: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 87
	i64 14007343973601849913, ; 169: Google.Apis.AndroidPublisher.v1.dll => 0xc2641521413f3239 => 10
	i64 14124974489674258913, ; 170: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 42
	i64 14172845254133543601, ; 171: Xamarin.AndroidX.MultiDex => 0xc4b00faaed35f2b1 => 68
	i64 14261073672896646636, ; 172: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 73
	i64 14438260825521943376, ; 173: RestSharp.dll => 0xc85f01b93fac7350 => 20
	i64 14486659737292545672, ; 174: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 61
	i64 14551742072151931844, ; 175: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 28
	i64 14644440854989303794, ; 176: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 66
	i64 14792063746108907174, ; 177: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 91
	i64 14852515768018889994, ; 178: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 49
	i64 14987728460634540364, ; 179: System.IO.Compression.dll => 0xcfff1ba06622494c => 96
	i64 14988210264188246988, ; 180: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 51
	i64 15076659072870671916, ; 181: System.ObjectModel.dll => 0xd13b0d8c1620662c => 101
	i64 15133485256822086103, ; 182: System.Linq.dll => 0xd204f0a9127dd9d7 => 103
	i64 15370334346939861994, ; 183: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 48
	i64 15540815214206815676, ; 184: Plugin.Fingerprint.dll => 0xd7ac11193ac88dbc => 19
	i64 15582737692548360875, ; 185: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 64
	i64 15609085926864131306, ; 186: System.dll => 0xd89e9cf3334914ea => 23
	i64 15620612276725577442, ; 187: BouncyCastle.Cryptography.dll => 0xd8c7901aa85576e2 => 4
	i64 15777549416145007739, ; 188: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 76
	i64 15810740023422282496, ; 189: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 89
	i64 15963349826457351533, ; 190: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 104
	i64 16154507427712707110, ; 191: System => 0xe03056ea4e39aa26 => 23
	i64 16565028646146589191, ; 192: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 98
	i64 16621146507174665210, ; 193: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 46
	i64 16677317093839702854, ; 194: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 71
	i64 16822611501064131242, ; 195: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 94
	i64 16833383113903931215, ; 196: mscorlib => 0xe99c30c1484d7f4f => 17
	i64 17024911836938395553, ; 197: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 34
	i64 17031351772568316411, ; 198: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 69
	i64 17037200463775726619, ; 199: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 57
	i64 17151170952569239713, ; 200: RestSharp => 0xee05331c4de338a1 => 20
	i64 17544493274320527064, ; 201: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 39
	i64 17704177640604968747, ; 202: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 65
	i64 17710060891934109755, ; 203: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 63
	i64 17838668724098252521, ; 204: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 21
	i64 17882897186074144999, ; 205: FormsViewGroup => 0xf82cd03e3ac830e7 => 9
	i64 17892495832318972303, ; 206: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 89
	i64 17928294245072900555, ; 207: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 97
	i64 18116111925905154859, ; 208: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 38
	i64 18121036031235206392, ; 209: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 69
	i64 18129453464017766560, ; 210: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 100
	i64 18305135509493619199, ; 211: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 70
	i64 18380184030268848184, ; 212: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 82
	i64 18433350178139604170 ; 213: Google.Apis.AndroidPublisher.v1 => 0xffd06a52ac6504ca => 10
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [214 x i32] [
	i32 53, i32 16, i32 43, i32 75, i32 76, i32 62, i32 95, i32 56, ; 0..7
	i32 52, i32 93, i32 88, i32 105, i32 90, i32 37, i32 3, i32 35, ; 8..15
	i32 64, i32 57, i32 18, i32 106, i32 36, i32 75, i32 15, i32 33, ; 16..23
	i32 63, i32 104, i32 18, i32 68, i32 0, i32 41, i32 52, i32 99, ; 24..31
	i32 60, i32 28, i32 26, i32 14, i32 47, i32 80, i32 27, i32 32, ; 32..39
	i32 30, i32 17, i32 72, i32 26, i32 11, i32 86, i32 90, i32 59, ; 40..47
	i32 34, i32 25, i32 78, i32 77, i32 24, i32 27, i32 1, i32 74, ; 48..55
	i32 53, i32 106, i32 40, i32 100, i32 5, i32 82, i32 39, i32 32, ; 56..63
	i32 77, i32 87, i32 85, i32 66, i32 67, i32 80, i32 79, i32 46, ; 64..71
	i32 22, i32 11, i32 84, i32 44, i32 72, i32 61, i32 19, i32 88, ; 72..79
	i32 9, i32 29, i32 62, i32 7, i32 60, i32 41, i32 50, i32 99, ; 80..87
	i32 56, i32 31, i32 25, i32 58, i32 55, i32 103, i32 31, i32 101, ; 88..95
	i32 86, i32 85, i32 2, i32 6, i32 92, i32 35, i32 98, i32 102, ; 96..103
	i32 59, i32 94, i32 13, i32 102, i32 6, i32 5, i32 45, i32 71, ; 104..111
	i32 79, i32 13, i32 70, i32 97, i32 4, i32 84, i32 36, i32 24, ; 112..119
	i32 47, i32 67, i32 16, i32 44, i32 93, i32 105, i32 2, i32 50, ; 120..127
	i32 40, i32 78, i32 48, i32 15, i32 37, i32 22, i32 30, i32 83, ; 128..135
	i32 8, i32 49, i32 73, i32 0, i32 83, i32 58, i32 33, i32 1, ; 136..143
	i32 55, i32 21, i32 81, i32 29, i32 12, i32 54, i32 65, i32 51, ; 144..151
	i32 7, i32 42, i32 96, i32 43, i32 12, i32 95, i32 14, i32 3, ; 152..159
	i32 81, i32 45, i32 91, i32 38, i32 8, i32 74, i32 92, i32 54, ; 160..167
	i32 87, i32 10, i32 42, i32 68, i32 73, i32 20, i32 61, i32 28, ; 168..175
	i32 66, i32 91, i32 49, i32 96, i32 51, i32 101, i32 103, i32 48, ; 176..183
	i32 19, i32 64, i32 23, i32 4, i32 76, i32 89, i32 104, i32 23, ; 184..191
	i32 98, i32 46, i32 71, i32 94, i32 17, i32 34, i32 69, i32 57, ; 192..199
	i32 20, i32 39, i32 65, i32 63, i32 21, i32 9, i32 89, i32 97, ; 200..207
	i32 38, i32 69, i32 100, i32 70, i32 82, i32 10 ; 208..213
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="non-leaf" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2, !3, !4, !5}
!llvm.ident = !{!6}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"branch-target-enforcement", i32 0}
!3 = !{i32 1, !"sign-return-address", i32 0}
!4 = !{i32 1, !"sign-return-address-all", i32 0}
!5 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
!6 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}

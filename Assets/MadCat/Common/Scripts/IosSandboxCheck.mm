extern "C" BOOL IosSandboxCheck_IsSandbox()
{
    return [[[[NSBundle mainBundle] appStoreReceiptURL] lastPathComponent] isEqualToString:@"sandboxReceipt"];
}

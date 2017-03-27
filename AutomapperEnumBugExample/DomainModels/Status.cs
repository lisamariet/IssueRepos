namespace AutomapperEnumBugExample.DomainModels
{
    public enum Status
    {
        Initialized = 1,
        Finalized = 50,
        AttentionNeeded = 53,
        ManualCreditCheck = 54,
        Canceled = 55,
        Processing = 75,
        Waiting = 77,
        CompletedWithErrors = 80,
        Done = 100,
        CompletedManually = 101,
        RejectedManually = 102
    }
}
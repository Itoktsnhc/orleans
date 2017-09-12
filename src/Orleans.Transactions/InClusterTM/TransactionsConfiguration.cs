﻿using System;

namespace Orleans.Transactions
{
    [Serializable]
    public class TransactionsConfiguration
    {
        /// <summary>
        /// The number of new Transaction Ids allocated on every write to the log.
        /// To avoid writing to log on every transaction start, transaction Ids are allocated in batches.
        /// </summary>
        public int TransactionIdAllocationBatchSize { get; set; } = DefaultTransactionIdAllocationBatchSize;
        public const int DefaultTransactionIdAllocationBatchSize = 50000;

        /// <summary>
        /// A new batch of transaction Ids will be automatically allocated if the available ids drop below
        /// this threshold.
        /// </summary>
        public int AvailableTransactionIdThreshold { get; set; } = DefaultAvailableTransactionIdThreshold;
        public const int DefaultAvailableTransactionIdThreshold = 20000;

        /// <summary>
        /// How long to preserve a transaction record in the TM memory after the transaction has completed.
        /// This is used to answer queries about the outcome of the transaction.
        /// </summary>
        public TimeSpan TransactionRecordPreservationDuration { get; set; } = DefaultTransactionRecordPreservationDuration;
        public static readonly TimeSpan DefaultTransactionRecordPreservationDuration = TimeSpan.FromMinutes(1);
    }
}

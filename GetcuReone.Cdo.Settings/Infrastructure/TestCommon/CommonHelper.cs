using GetcuReone.Cdi;
using GetcuReone.Cdm.Errors;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.Cdo.Settings.TestCommon
{
    public static class CommonHelper
    {
        private static void AssertError(GetcuReoneException exception, string code, string reason)
        {
            List<ErrorDetail> details = exception.ErrorDetails?.Where(d => d.Code.EqualsOrdinal(code)).ToList();

            if (details.IsNullOrEmpty())
                Assert.Fail($"ErrorDetails dot exists detail with '{code}' code.");

            ErrorDetail detail = details.FirstOrDefault(d => d.Reason.EqualsOrdinal(reason));

            if (detail == null)
                Assert.Fail($"ErrorDetails dot exists detail with '{reason}' reason.");
        }

        /// <summary>
        /// Check error code and reason.
        /// </summary>
        /// <param name="givenBlock"></param>
        /// <param name="code"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public static GivenBlock<GetcuReoneException, GetcuReoneException> AndAssertError<TIn>(this GivenBlock<TIn, GetcuReoneException> givenBlock, string code, string reason)
        {
            return givenBlock.And($"Check error. Code <{code}>, Reason <{reason}>.",
                error => AssertError(error, code, reason));
        }

        /// <summary>
        /// Check error code and reason.
        /// </summary>
        /// <param name="thenBlock"></param>
        /// <param name="code"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public static ThenBlock<GetcuReoneException, GetcuReoneException> AndAssertError<TIn>(this ThenBlock<TIn, GetcuReoneException> thenBlock, string code, string reason)
        {
            return thenBlock.And($"Check error. Code <{code}>, Reason <{reason}>.",
                error => AssertError(error, code, reason));
        }

        /// <summary>
        /// Check error code and reason.
        /// </summary>
        /// <param name="whenBlock"></param>
        /// <param name="code"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public static ThenBlock<GetcuReoneException, GetcuReoneException> ThenAssertError<TIn>(this WhenBlock<TIn, GetcuReoneException> whenBlock, string code, string reason)
        {
            return whenBlock.Then($"Check error. Code <{code}>, Reason <{reason}>.",
                error => AssertError(error, code, reason));
        }
    }
}

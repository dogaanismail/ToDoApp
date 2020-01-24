using PostSharp.Aspects;
using System;
using System.Transactions;

namespace ToDoApp.Core.Aspects.PostsSharp.TransactionAspects
{
    [Serializable]
    public class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        private readonly TransactionScopeOption _option;
        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public TransactionScopeAspect()
        {

        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}

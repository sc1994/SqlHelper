﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Explain;

namespace MSORM
{
    public class MSORM<T> : IMSORM<T>
    {
        private List<string> _show;

        public bool Exist()
        {
            throw new NotImplementedException();
        }

        public T First()
        {
            throw new NotImplementedException();
        }

        public TOther First<TOther>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TOther> Find<TOther>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find()
        {
            throw new NotImplementedException();
        }

        public (IEnumerable<T> data, int total) Page(int index, int size)
        {
            throw new NotImplementedException();
        }

        public (IEnumerable<TOther> data, int total) Page<TOther>(int index, int size)
        {
            throw new NotImplementedException();
        }

        public (IEnumerable<T> data, int total) Page()
        {
            throw new NotImplementedException();
        }

        public (IEnumerable<TOther> data, int total) Page<TOther>()
        {
            throw new NotImplementedException();
        }

        public IOrder<T> OrderA<TValue>(params Expression<Func<T, TValue>>[] exps)
        {
            throw new NotImplementedException();
        }

        public IOrder<T> OrderA(params Expression<Func<T, object>>[] exps)
        {
            throw new NotImplementedException();
        }

        public IOrder<T> OrderD(params Expression<Func<T, object>>[] exps)
        {
            throw new NotImplementedException();
        }

        public IWhere<T> Where(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public IWhere<T> Where(params Expression<Func<T, bool>>[] exps)
        {
            throw new NotImplementedException();
        }

        public IWhere<T> Where(Expression<Func<T, bool[]>> exp)
        {
            throw new NotImplementedException();
        }

        public IWhere<T> In<TValue>(Expression<Func<T, TValue>> exp, IEnumerable<TValue> values)
        {
            throw new NotImplementedException();
        }

        public IWhere<T> NotIn<TValue>(Expression<Func<T, TValue>> exp, IEnumerable<TValue> values)
        {
            throw new NotImplementedException();
        }

        public IWhere<T> LikeF<TValue>(Expression<Func<T, TValue>> exp, TValue value)
        {
            throw new NotImplementedException();
        }

        public IWhere<T> LikeL<TValue>(Expression<Func<T, TValue>> exp, TValue value)
        {
            throw new NotImplementedException();
        }

        public IWhere<T> LikeR<TValue>(Expression<Func<T, TValue>> exp, TValue value)
        {
            throw new NotImplementedException();
        }

        public IJoin<T> Join<TJoin>(Expression<Func<T, TJoin, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public IJoin<T> JoinL<TLJoin>(Expression<Func<T, TLJoin, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public IJoin<T> JoinR<TRJoin>(Expression<Func<T, TRJoin, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public IJoin<T> JoinF<TFJoin>(Expression<Func<T, TFJoin, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public ISelect<T> Select<TValue>(Expression<Func<T, TValue>> exp)
        {
            ExplainTool.Explain(exp);
            throw new NotImplementedException();
        }

        public ISelect<T> Select<TValue>(params Expression<Func<T, TValue>>[] exps)
        {
            throw new NotImplementedException();
        }

        public ISelect<T> Select<TValue>(Expression<Func<T, TValue>> exp, string alias)
        {
            throw new NotImplementedException();
        }

        public ISelect<T> Select<TValue>(params (Expression<Func<T, TValue>> exp, string alias)[] exps)
        {
            throw new NotImplementedException();
        }

        public ISelect<T> Select<TValue>(Expression<Func<T, TValue[]>> exps)
        {
            throw new NotImplementedException();
        }

        public ISelect<T> Select(params Expression<Func<T, object>>[] exps)
        {
            throw new NotImplementedException();
        }

        public ISelect<T> Select(Expression<Func<T, object[]>> exps)
        {
            throw new NotImplementedException();
        }

        public int Update(int top = 0)
        {
            throw new NotImplementedException();
        }

        public List<UpdateRecord> Update(int top = 0, bool record = false)
        {
            throw new NotImplementedException();
        }

        private void AddSelect(string field, string alias = null)
        {
            if (alias != null)
            {
                _show.Add($"\r\n{field} AS {alias}");
            }
            else
            {
                _show.Add($"\r\n{field}");
            }
        }
    }

    public interface IMSORM<T> : ISelect<T>
    {

    }

    public interface ISelect<T> : IJoin<T>
    {
        ISelect<T> Select<TValue>(params Expression<Func<T, TValue>>[] exps);
        ISelect<T> Select<TValue>(Expression<Func<T, TValue>> exp, string alias);
        ISelect<T> Select<TValue>(params (Expression<Func<T, TValue>> exp, string alias)[] exps);
        ISelect<T> Select<TValue>(Expression<Func<T, TValue[]>> exps);
        ISelect<T> Select(params Expression<Func<T, object>>[] exps);
        ISelect<T> Select(Expression<Func<T, object[]>> exps);
    }

    public interface IJoin<T> : IWhere<T>
    {
        IJoin<T> Join<TJoin>(Expression<Func<T, TJoin, bool>> exp); // todo 扩展支持 "join a on a.id = id and xxx" and后面的语法
        IJoin<T> JoinL<TLJoin>(Expression<Func<T, TLJoin, bool>> exp);
        IJoin<T> JoinR<TRJoin>(Expression<Func<T, TRJoin, bool>> exp);
        IJoin<T> JoinF<TFJoin>(Expression<Func<T, TFJoin, bool>> exp);
    }

    public interface IWhere<T> : IOrder<T>, IUpdate
    {
        IWhere<T> Where(params Expression<Func<T, bool>>[] exps);
        IWhere<T> Where(Expression<Func<T, bool[]>> exp);
        IWhere<T> In<TValue>(Expression<Func<T, TValue>> exp, IEnumerable<TValue> values);
        IWhere<T> NotIn<TValue>(Expression<Func<T, TValue>> exp, IEnumerable<TValue> values);
        IWhere<T> LikeF<TValue>(Expression<Func<T, TValue>> exp, TValue value);
        IWhere<T> LikeL<TValue>(Expression<Func<T, TValue>> exp, TValue value);
        IWhere<T> LikeR<TValue>(Expression<Func<T, TValue>> exp, TValue value);
    }

    public interface IOrder<T> : IMethod<T>
    {
        IOrder<T> OrderA<TValue>(params Expression<Func<T, TValue>>[] exps);
        IOrder<T> OrderA(params Expression<Func<T, object>>[] exps);
        IOrder<T> OrderD(params Expression<Func<T, object>>[] exps);
    }

    public interface IMethod<T>
    {
        bool Exist();
        T First();
        TOther First<TOther>();
        IEnumerable<TOther> Find<TOther>();
        IEnumerable<T> Find();
        (IEnumerable<T> data, int total) Page(int index, int size);
        (IEnumerable<TOther> data, int total) Page<TOther>(int index, int size);
    }

    public interface IUpdate
    {
        int Update(int top = 0);
        List<UpdateRecord> Update(int top = 0, bool record = false);
    }

    public class UpdateRecord
    {
        public string Field { get; set; }

        public object Old { get; set; }

        public object New { get; set; }
    }

    public class Test
    {
        public string Name { get; set; }

        public long Id { get; set; }

        public DateTime Date { get; set; }

        public void Xxx()
        {
            var data = new MSORM<Test>()
                .Select(x => x.Name, x => x.Id)
                .Select(x => new[] { x.Name, x.Name })
                .Where(x => x.Name == "123", x => x.Id == 3)
                .Where(x => x.Date == DateTime.Now.Date)
                .Where(x => new[] { x.Name == "123", x.Id == 2, x.Name == "123" })
                .In(x => x.Id, new List<long> { 1, 2, 34, 5 })
                .LikeF(x => x.Name, "s")
                .OrderA(x => x.Name, x => x.Id)
                .Page(1, 3);

            var a = data.data;
            var b = data.total;
        }
    }



    public class Test2
    {
        public string Name2 { get; set; }
    }
}

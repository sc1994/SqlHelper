﻿using ORM.Interface.IQuery;
using System;
using System.Linq.Expressions;

namespace ORM.Interface
{
    public interface IQueryGroup<T> : IHaving<T>
    {
        IQueryOrder<T> Group(Expression<Func<T, object[]>> exp);
        IQueryOrder<T> Group(params Expression<Func<T, object>>[] exps);
    }

    public interface IQueryGroup<T, TJoin> : IHaving<T, TJoin>
    {
        IQueryOrder<T, TJoin> Group(Expression<Func<T, TJoin, object[]>> exp);
        IQueryOrder<T, TJoin> Group(params Expression<Func<T, TJoin, object>>[] exps);
    }

    public interface IQueryGroup<T, TJoin1, TJoin2> : IHaving<T, TJoin1, TJoin2>
    {
        IQueryOrder<T, TJoin1, TJoin2> Group(Expression<Func<T, TJoin1, TJoin2, object[]>> exp);
        IQueryOrder<T, TJoin1, TJoin2> Group(params Expression<Func<T, TJoin1, TJoin2, object>>[] exps);
    }

    public interface IQueryGroup<T, TJoin1, TJoin2, TJoin3> : IHaving<T, TJoin1, TJoin2, TJoin3>
    {
        IQueryOrder<T, TJoin1, TJoin2, TJoin3> Group(Expression<Func<T, TJoin1, TJoin2, TJoin3, object[]>> exp);
        IQueryOrder<T, TJoin1, TJoin2, TJoin3> Group(params Expression<Func<T, TJoin1, TJoin2, TJoin3, object>>[] exps);
    }

    public interface IQueryGroup<T, TJoin1, TJoin2, TJoin3, TJoin4> : IHaving<T, TJoin1, TJoin2, TJoin3, TJoin4>
    {
        IQueryOrder<T, TJoin1, TJoin2, TJoin3, TJoin4> Group(Expression<Func<T, TJoin1, TJoin2, TJoin3, TJoin4, object[]>> exp);
        IQueryOrder<T, TJoin1, TJoin2, TJoin3, TJoin4> Group(params Expression<Func<T, TJoin1, TJoin2, TJoin3, TJoin4, object>>[] exps);
    }
}
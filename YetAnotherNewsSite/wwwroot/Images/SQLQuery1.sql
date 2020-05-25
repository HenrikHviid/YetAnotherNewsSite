 Create proc Sp_Articles_LazyLoad

@PageIndex int,

@PageSize int

as

begin

Select * from Articles order by ArticleId asc offset @PageSize*(@PageIndex-1) Rows fetch next @PageSize rows only

end
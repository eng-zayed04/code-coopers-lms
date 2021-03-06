﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestModel
{
    using System.Linq.Expressions;
    using Commons.RequestModel;
    using Commons.ViewModel;

    using Model;

    public class CourseRequestModel : RequestModel<Course>
    {
        public string TeacherId { get; set; }

        public string StudentId { get; set; }

        public CourseRequestModel(string keyword, string orderBy = "Modified", string isAscending = "False")
            : base(keyword, orderBy, isAscending)
        {
        }

        protected override Expression<Func<Course, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                this.ExpressionObj = this.ExpressionObj.And(x => x.Name.ToLower().Contains(Keyword));
            }
            
            if (!string.IsNullOrWhiteSpace(TeacherId))
            {
                this.ExpressionObj = this.ExpressionObj.And(x => x.TeacherId == TeacherId);
            }

            // we will add student's course search logic after we introduce enrollment feature 


            return this.ExpressionObj;
        }

        public override Expression<Func<Course, DropdownViewModel>> Dropdown()
        {
            throw new NotImplementedException();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Entity;
using Mdia.Model.Model;

namespace Mdia.Model.Translator
{
    public class RightTranslator : BaseTranslator<Right, RIGHT>
    {
        public override Right TranslateToModel(RIGHT rightEntity)
        {
            try
            {
                Right right = null;
                if (rightEntity != null)
                {
                    right = new Right();
                    right.Id = (int)rightEntity.Right_Id;
                    right.Name = rightEntity.Right_Name;
                    right.Description = rightEntity.Right_Description;
                }

                return right;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Right> TranslateToModel(IEnumerable<ROLE_RIGHT> roleRightEntities)
        {
            try
            {
                List<Right> rights = null;
                if (roleRightEntities != null)
                {
                    rights = new List<Right>();
                    roleRightEntities = roleRightEntities.ToList();
                                        
                    foreach (ROLE_RIGHT roleRightEntity in roleRightEntities)
                    {
                        if (roleRightEntity.RIGHT != null)
                        {
                            Right right = TranslateToModel(roleRightEntity.RIGHT);
                            rights.Add(right);
                        }
                    }
                }

                return rights;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override RIGHT TranslateToEntity(Right right)
        {
            try
            {
                RIGHT rightEntity = null;
                if (right != null)
                {
                    rightEntity = new RIGHT();
                    rightEntity.Right_Id = right.Id;
                    rightEntity.Right_Name = right.Name;
                    rightEntity.Right_Description = right.Description;
                }

                return rightEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}

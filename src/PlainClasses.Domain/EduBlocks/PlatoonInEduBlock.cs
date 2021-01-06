using System;
using PlainClasses.Domain.Platoons;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks
{
    public class PlatoonInEduBlock : Entity
    {
        public Guid Id { get; private set; }
        public Guid PlatoonId { get; private set; }
        public Guid EduBlockId { get; private set; }

        #region Ef_Config

        public Platoon Platoon { get; set; }
        public EduBlock EduBlock { get; set; }

        #endregion

        private PlatoonInEduBlock() { }

        private PlatoonInEduBlock(Guid eduBlockId, Guid platoonId)
        {
            Id = Guid.NewGuid();
            EduBlockId = eduBlockId;
            PlatoonId = platoonId;
        }

        public static PlatoonInEduBlock AddPlatoonToEduBlock(Guid eduBlockId, Guid platoonId)
        {
            // check rule!!!

            return new PlatoonInEduBlock(eduBlockId, platoonId);
        }
    }
}
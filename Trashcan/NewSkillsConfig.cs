/*using STRINGS;
using System.Collections.Generic;
using Database;

namespace New_Elements
{
    public class NewSkills : ResourceSet<Skill>
    {
        public Skill Technicals3;
        public NewSkills(ResourceSet parent)
      : base(nameof(NewSkills), parent)
        {
            this.Technicals3 = NewSkills.AddSkill(new Skill(nameof(Technicals3), (string)DUPLICANTS.ROLES.POWER_TECHNICIAN.NAME, (string)DUPLICANTS.ROLES.POWER_TECHNICIAN.DESCRIPTION, "", 1, "hat_role_technicals2", "skillbadge_role_technicals2", Db.Get().SkillGroups.Technicals.Id, new List<SkillPerk>()
      {
        Db.Get().SkillPerks.IncreaseMachineryMedium,
        Db.Get().SkillPerks.CanPowerTinker
      }, new List<string>() { Skills.Engineering1.Id }));
        }
        private Skill AddSkill(Skill skill) => DlcManager.IsContentActive(skill.dlcId) ? this.Add(skill) : skill;
    }
}*/
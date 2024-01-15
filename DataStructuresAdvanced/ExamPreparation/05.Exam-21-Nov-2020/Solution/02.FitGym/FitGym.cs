namespace _02.FitGym
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class FitGym : IGym
	{
		private readonly Dictionary<int, Member> membersById;

		private readonly Dictionary<int, Trainer> trainersById;

		private readonly Dictionary<Trainer, HashSet<Member>> membersByTrainer;

		public FitGym()
		{
			this.membersById = new Dictionary<int, Member>();
			this.trainersById = new Dictionary<int, Trainer>();
			this.membersByTrainer = new Dictionary<Trainer, HashSet<Member>>();
		}

		public int MemberCount => this.membersById.Count;

		public int TrainerCount => this.trainersById.Count;

		public void AddMember(Member member)
		{
			if (this.membersById.ContainsKey(member.Id))
			{
				throw new ArgumentException();
			}

			this.membersById.Add(member.Id, member);
		}

		public void HireTrainer(Trainer trainer)
		{
			if (this.trainersById.ContainsKey(trainer.Id))
			{
				throw new ArgumentException();
			}

			this.trainersById.Add(trainer.Id, trainer);

			this.membersByTrainer.Add(trainer, new HashSet<Member>());
		}

		public void Add(Trainer trainer, Member member)
		{
			if (!this.trainersById.ContainsKey(trainer.Id)
				|| (this.membersById.ContainsKey(member.Id) && this.membersById[member.Id].Trainer != null))
			{
				throw new ArgumentException();
			}

			if (!this.membersById.ContainsKey(member.Id))
			{
				this.membersById.Add(member.Id, member);
			}

			member.Trainer = trainer;

			this.membersByTrainer[trainer].Add(member);
		}

		public bool Contains(Member member) => this.membersById.ContainsKey(member.Id);

		public bool Contains(Trainer trainer) => this.trainersById.ContainsKey(trainer.Id);

		public Trainer FireTrainer(int id)
		{
			if (!this.trainersById.ContainsKey(id))
			{
				throw new ArgumentException();
			}

			Trainer trainer = this.trainersById[id];

			this.trainersById.Remove(id);

			foreach (var member in this.membersByTrainer[trainer])
			{
				member.Trainer = null;
			}

			this.membersByTrainer.Remove(trainer);

			return trainer;
		}

		public Member RemoveMember(int id)
		{
			if (!this.membersById.ContainsKey(id))
			{
				throw new ArgumentException();
			}

			Member member = this.membersById[id];

			this.membersById.Remove(id);

			if (member.Trainer != null)
			{
				this.membersByTrainer[member.Trainer].Remove(member);
			}

			return member;
		}

		public IEnumerable<Member> GetMembersInOrderOfRegistrationAscendingThenByNamesDescending()
			=> this.membersById.Values
			   .OrderBy(m => m.RegistrationDate)
			   .ThenByDescending(m => m.Name);

		public IEnumerable<Trainer> GetTrainersInOrdersOfPopularity()
			=> this.trainersById.Values
			   .OrderBy(t => t.Popularity);

		public IEnumerable<Member> GetTrainerMembersSortedByRegistrationDateThenByNames(Trainer trainer)
			=> this.membersByTrainer[trainer]
			   .OrderBy(m => m.RegistrationDate)
			   .ThenBy(m => m.Name);

		public IEnumerable<Member> GetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames(int lo, int hi)
			=> this.membersById.Values
			   .Where(m => m.Trainer?.Popularity >= lo && m.Trainer?.Popularity <= hi)
			   .OrderBy(m => m.Visits)
			   .ThenBy(m => m.Name);

		public Dictionary<Trainer, HashSet<Member>> GetTrainersAndMemberOrderedByMembersCountThenByPopularity()
			=> this.membersByTrainer
			   .OrderBy(kvp => kvp.Value.Count)
			   .ThenBy(kvp => kvp.Key.Popularity)
			   .ToDictionary(x => x.Key, x => x.Value);
	}
}
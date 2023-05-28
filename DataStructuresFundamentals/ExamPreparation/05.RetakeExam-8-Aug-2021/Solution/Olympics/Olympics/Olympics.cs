using System;
using System.Collections.Generic;
using System.Linq;

public class Olympics : IOlympics
{
	private readonly Dictionary<int, Competitor> competitorsById = new Dictionary<int, Competitor>();

	private readonly Dictionary<int, Competition> competitionsById = new Dictionary<int, Competition>();

	public void AddCompetitor(int id, string name)
	{
		if (this.competitorsById.ContainsKey(id))
		{
			throw new ArgumentException();
		}

		Competitor competitor = new Competitor(id, name);

		this.competitorsById.Add(id, competitor);
	}

	public void AddCompetition(int id, string name, int score)
	{
		if (this.competitionsById.ContainsKey(id))
		{
			throw new ArgumentException();
		}

		Competition competition = new Competition(name, id, score);

		this.competitionsById.Add(id, competition);
	}

	public void Compete(int competitorId, int competitionId)
	{
		if (!this.competitorsById.ContainsKey(competitorId)
			|| !this.competitionsById.ContainsKey(competitionId))
		{
			throw new ArgumentException();
		}

		this.competitionsById[competitionId].Competitors.Add(this.competitorsById[competitorId]);

		this.competitorsById[competitorId].TotalScore += this.competitionsById[competitionId].Score;
	}

	public void Disqualify(int competitionId, int competitorId)
	{
		if (!this.competitionsById.ContainsKey(competitionId)
			|| !this.competitorsById.ContainsKey(competitorId))
		{
			throw new ArgumentException();
		}

		Competition competition = this.competitionsById[competitionId];

		Competitor competitor = competition.Competitors.FirstOrDefault(c => c.Id == competitorId)
			?? throw new ArgumentException();

		competition.Competitors.Remove(competitor);

		this.competitorsById[competitorId].TotalScore -= competition.Score;
	}

	public IEnumerable<Competitor> GetByName(string name)
	{
		List<Competitor> competitors = this.competitorsById.Values
			.Where(c => c.Name == name)
			.OrderBy(c => c.Id)
			.ToList();

		if (competitors.Count == 0)
		{
			throw new ArgumentException();
		}

		return competitors;
	}

	public IEnumerable<Competitor> FindCompetitorsInRange(long min, long max)
		=> this.competitorsById.Values
			.Where(c => c.TotalScore > min && c.TotalScore <= max)
			.OrderBy(c => c.Id);

	public IEnumerable<Competitor> SearchWithNameLength(int min, int max)
		=> this.competitorsById.Values
			.Where(c => c.Name.Length >= min && c.Name.Length <= max)
			.OrderBy(c => c.Id);

	public bool Contains(int competitionId, Competitor comp)
	{
		if (!this.competitionsById.ContainsKey(competitionId))
		{
			throw new ArgumentException();
		}

		Competitor competitor = this.competitionsById[competitionId].Competitors.FirstOrDefault(c => c.Id == comp.Id);

		return competitor != null;
	}

	public Competition GetCompetition(int id)
	{
		if (!this.competitionsById.ContainsKey(id))
		{
			throw new ArgumentException();
		}

		return this.competitionsById[id];
	}

	public int CompetitorsCount() => this.competitorsById.Values.Count;

	public int CompetitionsCount() => this.competitionsById.Values.Count;
}
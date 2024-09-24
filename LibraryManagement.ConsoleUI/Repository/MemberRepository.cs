using LibraryManagement.ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagement.ConsoleUI.Repository;

public class MemberRepository : BaseRepository, IMemberRepository
{
    private List<Member> members;
    public MemberRepository()
    {
        members = Members();
    }
    public Member? Add(Member member)
    {
        members.Add(member);
        return member;
    }

    public List<Member> GetAll()
    {
        return members;
    }

    public Member? GetById(int id)
    {
        return members.Where(x=>x.Id == id).FirstOrDefault();
    }

    public Member? Remove(int id)
    {
        Member member = GetById(id);
        members.Remove(member);
        return member;
    }

    public Member? Update(Member member)
    {
        throw new NotImplementedException();
    }
}

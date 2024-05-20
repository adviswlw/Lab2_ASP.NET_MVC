using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Lab2.Models;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T Get(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
}

public class HospitalRepository : IRepository<Hospital>
{
    private readonly ApplicationDbContext _context;

    public HospitalRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// получить всех больниц
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Hospital> GetAll()
    {
        return _context.Hospitals.Include(h => h.Patients);
    }

    /// <summary>
    /// получить больницы по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Hospital Get(int id)
    {
        return _context.Hospitals.Include(h => h.Patients).FirstOrDefault(h => h.Id == id);
    }

    /// <summary>
    /// добавление больницы
    /// </summary>
    /// <param name="hospital"></param>
    public void Add(Hospital hospital)
    {
        _context.Hospitals.Add(hospital);
        _context.SaveChanges();
    }

    /// <summary>
    /// редактирование больницы
    /// </summary>
    /// <param name="hospital"></param>
    public void Update(Hospital hospital)
    {
        _context.Hospitals.Update(hospital);
        _context.SaveChanges();
    }

    /// <summary>
    /// уаление больницы
    /// </summary>
    /// <param name="id"></param>
    public void Delete(int id)
    {
        var hospital = Get(id);
        if (hospital != null)
        {
            _context.Hospitals.Remove(hospital);
            _context.SaveChanges();
        }
    }
}

public class PatientRepository : IRepository<Patient>
{
    private readonly ApplicationDbContext _context;

    public PatientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// получить всех пациентов
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Patient> GetAll()
    {
        return _context.Patients.Include(p => p.Hospital);
    }

    /// <summary>
    /// получить пациента по id 
    /// </summary>
    /// <param name="patientId"></param>
    /// <returns></returns>
    public Patient Get(int id)
    {
        return _context.Patients.Include(p => p.Hospital).FirstOrDefault(p => p.Id == id);
    }

    /// <summary>
    /// добавление пациента
    /// </summary>
    /// <param name="patient"></param>
    public void Add(Patient patient)
    {
        _context.Patients.Add(patient);
        _context.SaveChanges();
    }

    /// <summary>
    /// редактирование пациента
    /// </summary>
    /// <param name="patient"></param>
    public void Update(Patient patient)
    {
        _context.Patients.Update(patient);
        _context.SaveChanges();
    }

    /// <summary>
    /// удаление пациента
    /// </summary>
    /// <param name="patientId"></param>
    public void Delete(int id)
    {
        var patient = Get(id);
        if (patient != null)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }
    }
}

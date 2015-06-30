public interface IRepository {
    Person[] getAllPersons();
    Person getPersonById(Long id);
    void addOrUpdatePerson(Person p);
}

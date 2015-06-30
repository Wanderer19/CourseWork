import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;
import org.hibernate.service.ServiceRegistry;
import org.hibernate.service.ServiceRegistryBuilder;

public class Repository implements IRepository{
    private static SessionFactory factory;
    private static ServiceRegistry serviceRegistry;
    static {
        try{
            Configuration configuration = new Configuration();
            configuration.configure();
            serviceRegistry = new ServiceRegistryBuilder().applySettings(configuration.getProperties()).buildServiceRegistry();
            factory = configuration.buildSessionFactory(serviceRegistry);
        }catch (Throwable ex) {
            System.err.println("Failed to create sessionFactory object." + ex);
            throw new ExceptionInInitializerError(ex);
        }
    }

    public Person getPersonById(Long id1){
        Session session = factory.openSession();
        org.hibernate.Transaction transaction = null;
        Person result = null;
        try {
            transaction = session.beginTransaction();
            Object[] persons = session.createQuery("FROM Person where id = " + id1).list().toArray();

            if (persons.length != 0){
                result = (Person)persons[0];
            }
        }
        catch (HibernateException exception){
            if (transaction != null){
                transaction.rollback();
            }
            exception.printStackTrace();
        }
        finally {
            session.close();
        }

        return result;
    }

    public Person[] getAllPersons(){
        Session session = factory.openSession();
        org.hibernate.Transaction transaction = null;
        Person[] result = null;
        try{
            transaction = session.beginTransaction();

            Object[] persons = session.createQuery("FROM Person").list().toArray();
            result = new Person[persons.length];
            for (int i = 0; i < result.length; ++i){
                result[i] = (Person)persons[i];
            }
        }
        catch (HibernateException exception){
            if (transaction != null){
                transaction.rollback();
            }

            exception.printStackTrace();
        }
        finally {
            session.close();
        }

        return result;
    }

    public void addOrUpdatePerson(Person person) {
        Session session = factory.openSession();
        org.hibernate.Transaction transaction = null;
        try{
            transaction = session.beginTransaction();
            session.saveOrUpdate(person);
            transaction.commit();
        }
        catch (HibernateException exception){
            if (transaction != null){
                transaction.rollback();
            }

            exception.printStackTrace();
        }
        finally {
            session.close();
        }
    }
}

package domain;

import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;
import org.hibernate.service.ServiceRegistry;
import org.hibernate.service.ServiceRegistryBuilder;

public class ContactsRepository {
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

    public Contact[] getAll(){
        Session session = factory.openSession();
        org.hibernate.Transaction transaction = null;
        Contact[] result = null;
        try {
            transaction = session.beginTransaction();
            Object[] contacts = session.createQuery("from domain.Contact").list().toArray();

            int contactsCount = contacts.length;
            result = new Contact[contactsCount];
            for (int i = 0; i < contactsCount; ++i){
                result[i] = (Contact)contacts[i];
            }

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

        return result;
    }
}

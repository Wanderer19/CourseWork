package domain;

import org.hibernate.SessionFactory;
import org.hibernate.service.ServiceRegistry;

import java.util.ArrayList;

public class ContactsRepository {
    private static SessionFactory factory;
    private static ServiceRegistry serviceRegistry;

    private static Contact[] contacts = new Contact[]{
            new Contact(1, "masha", "Telyatnikova"),
            new Contact(2, "dasha", "Pastukhova"),
            new Contact(3, "nastya", "Mazaeva"),
            new Contact(4, "sasha", "braun"),
            new Contact(5, "denis", "dublennikh"),
            new Contact(6, "fedor", "fominikh")
    };
    static {
        /*try{
            Configuration configuration = new Configuration();
            configuration.configure();
            serviceRegistry = new ServiceRegistryBuilder().applySettings(configuration.getProperties()).buildServiceRegistry();
            factory = configuration.buildSessionFactory(serviceRegistry);
        }catch (Throwable ex) {
            System.err.println("Failed to create sessionFactory object." + ex);
            throw new ExceptionInInitializerError(ex);
        }*/
    }

    public Contact[] getAll(){
        /*Session session = factory.openSession();
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

        return result;*/

        return contacts;
    }

    public Contact findById(int id){
        for (Contact contact : contacts){
            if (contact.getId() == id){
                return contact;
            }
        }

        return null;
    }

    public ArrayList<Contact> findByStartName(String startName){
        ArrayList<Contact> result = new ArrayList<Contact>();

        for (Contact contact:contacts){
            if (contact.getFirstName().startsWith(startName)){
                result.add(contact);
            }
        }
        return result;
    }
}

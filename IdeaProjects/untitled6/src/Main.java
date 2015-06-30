import domain.Contact;
import domain.ContactsRepository;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;
import org.hibernate.service.ServiceRegistry;
import org.hibernate.service.ServiceRegistryBuilder;

public class Main {

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


    public static void main(final String[] args) throws Exception {
        ContactsRepository repository = new ContactsRepository();
        Contact[] contacts = repository.getAll();

        for (Contact contact : contacts){
            System.out.println(contact.getFirstName() + " " + contact.getLastName());
        }
    }
}

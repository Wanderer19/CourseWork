import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;
import org.hibernate.service.ServiceRegistry;
import org.hibernate.service.ServiceRegistryBuilder;

public class GuestbookRepository implements IGuestbookRepository {

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

    @Override
    public User getUserByLogin(String login1) {
        Session session = factory.openSession();
        org.hibernate.Transaction transaction = null;
        User result = null;
        try{
            transaction = session.beginTransaction();

            Object[] users = session.createQuery("FROM User where login = " + login1).list().toArray();
            if (users.length  != 0){
                result = (User)users[0];
            }
        }
        catch(HibernateException exception){
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

    @Override
    public void addOrUpdateUser(User user) {
        Session session = factory.openSession();
        org.hibernate.Transaction transaction = null;

        try {
            transaction = session.beginTransaction();
            session.saveOrUpdate(user);
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

    @Override
    public boolean containsLogin(String login1) {
        Session session = factory.openSession();
        org.hibernate.Transaction transaction = null;
        boolean result = false;
        try{
            transaction = session.beginTransaction();

            int usersCount = (int)session.createQuery("select count(*) FROM User where login = " + login1)
                                            .uniqueResult();
            if (usersCount != 0){
                result = true;
            }
        }
        catch(HibernateException exception){
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

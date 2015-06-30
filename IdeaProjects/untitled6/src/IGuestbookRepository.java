public interface IGuestbookRepository {
    User getUserByLogin(String login);
    void addOrUpdateUser(User user);
    boolean containsLogin(String login);
}

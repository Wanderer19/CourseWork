public class Guestbook {
    private IGuestbookRepository guestbookRepository;

    public Guestbook(IGuestbookRepository guestbookRepository){
        this.guestbookRepository = guestbookRepository;
    }

    public boolean registerUser(String login, String password, String name){
        if (guestbookRepository.containsLogin(login)){
            return false;
        }

        User user = new User(name, login, password);
        guestbookRepository.addOrUpdateUser(user);

        return true;
    }

    public boolean addMessageToUser(String login, String messageText){
        Message message = new Message();
        message.setText(messageText);

        if (guestbookRepository.containsLogin(login)){
            return false;
        }

        User user = guestbookRepository.getUserByLogin(login);
        user.addMessage(message);

        guestbookRepository.addOrUpdateUser(user);

        return true;
    }
}

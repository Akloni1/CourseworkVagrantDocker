Vagrant.configure('2') do | config |
    config.vm.define 'base' do |base|
        base.vm.box = 'Ubuntu-Vagrant'
        base.vm.hostname = 'base.lab'
        base.vm.provider 'virtualbox' do |vb|
            vb.customize ['modifyvm', :id, '--memory', '1024']
        end
        base.vm.network "forwarded_port", guest: 5050, host: 8080
        base.vm.provision :docker
        base.vm.provision :docker_compose, yml: "/vagrant/docker-compose.yml", run: "always"
    end
end
using System;
using System.Xml.Schema;

namespace proyectoUniversidad
{
    public class Persona
    {
        private string tipo;
        private string nombre;

        public Persona(string pNombre, string pTipo)
        {
            nombre = pNombre;
            tipo = pTipo;
        }

        public string darNombre()
        {
            return nombre;
        }
    }

    public class Estudiante : Persona
    {
        private Materia[] materias;

        public Estudiante(string pNombre, string pTipo) : base(pNombre, pTipo)
        {

        }

        public void registrarMaterias(Materia[] pMaterias)
        {
            materias = pMaterias;
        }

        public Materia[] darMaterias()
        {
            return materias;
        }
    }

    public class Profesor : Persona
    {
        
        public Profesor(string pNombre, string pTipo) : base(pNombre, pTipo)
        {

        }

    }

    public class Administrativo : Persona
    {
        public Administrativo(string pNombre, string pTipo) : base(pNombre, pTipo)
        {
        }

        public void retirarAsignatura(Materia[] pListaMaterias, string pCodigoMateria)
        {
            for (int i = 0; i < pListaMaterias.Length; i++)
            {
                if (pListaMaterias[i] != null && pCodigoMateria == pListaMaterias[i].darCodigoMateria())
                {
                    pListaMaterias[i] = null;
                }
            }
        }
    }

    public class Materia
    {
        private string codigo;
        private string grupo;

        private Profesor profesor;
        private string horario;

        private string nombreMateria;

        public Materia(string pCodigo, string pGrupo, string pnombreMateria, Profesor pProfesor, string pHorario)
        {
            codigo = pCodigo;
            grupo = pGrupo;
            profesor = pProfesor;
            horario = pHorario;
            nombreMateria = pnombreMateria;
        }
        public string darnombremateria()
        {
            return nombreMateria;
        }

        public string darCodigoMateria()
        {
            return codigo;
        }

        public string dargrupo()
        {
            return grupo;
        }
        public string darhorario()
        {
            return horario ;
        }
        public Profesor darprofesor()
        {
            return profesor;
        }

    }

    class Program
    {
        static int cantidadProfesores = 2;
        static int cantidadAdministrativos = 2;
        static int cantidadEstudiantes = 10;

        static Profesor[] profesores = new Profesor[cantidadProfesores];
        static Administrativo[] administrativos = new Administrativo[cantidadAdministrativos];
        static Estudiante[] estudiantes = new Estudiante[cantidadEstudiantes];

        static void Main(string[] args)
        {
            Console.WriteLine("Programa Iniciado ");
            Console.WriteLine("Daniel Hernandez ");
            Console.WriteLine("Juan Camilo Baron ");
            Console.WriteLine("Javier Reyes ");
            string nombrePersona = "";

            for (int i = 0; i < cantidadProfesores; i++)
            {
                Console.WriteLine("Por favor ingresa el nombre del profesor: " + (i + 1));
                nombrePersona = Console.ReadLine();
                Profesor profesorActual = new Profesor(nombrePersona, "profesor");
                profesores[i] = profesorActual;
            }

            for (int i = 0; i < cantidadAdministrativos; i++)
            {
                Console.WriteLine("Por favor ingresa el nombre del administrativo: " + (i + 1));
                nombrePersona = Console.ReadLine();
                Administrativo administrativoActual = new Administrativo(nombrePersona, "administrativo");
                administrativos[i] = administrativoActual;
            }

            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                Console.WriteLine("Por favor ingresa el nombre del estudiante: " + (i + 1));
                nombrePersona = Console.ReadLine();

                Estudiante estudianteActual = new Estudiante(nombrePersona, "estudiante");
                estudiantes[i] = estudianteActual;

                Console.WriteLine("Por favor indica cuantas materias va a ver el estudiante " + nombrePersona);
                int cantidadMaterias = Convert.ToInt32(Console.ReadLine());

                Materia[] materiasActuales = new Materia[cantidadMaterias];
                for (int j = 0; j < cantidadMaterias; j++)
                {
                    Console.WriteLine("Por favor ingresa el código de la materia " + (j + 1) + " del estudiante " + nombrePersona);
                    string codigoMateria = Console.ReadLine();

                    Console.WriteLine("Por favor ingresa el nombre de la materia " + (j + 1) + " del estudiante " + nombrePersona);
                    string nombreMateria = Console.ReadLine();

                    Console.WriteLine("Por favor ingresa el grupo de la materia " + (j + 1) + " del estudiante " + nombrePersona);
                    string grupoMateria = Console.ReadLine();

                    Console.WriteLine("Por favor ingresa el indice del profesor de la materia " + (j + 1) + " del estudiante " + nombrePersona);
                    int indiceProfesor = Convert.ToInt32(Console.ReadLine());
                    Profesor profesorActual = profesores[indiceProfesor];

                    Console.WriteLine("Por favor ingresa el horario de la materia " + (j + 1) + " del estudiante " + nombrePersona);
                    string horario = Console.ReadLine();

                    Materia materiaActual = new Materia(codigoMateria, grupoMateria, nombreMateria,  profesorActual, horario);
                    materiasActuales[j] = materiaActual;
                }
                estudianteActual.registrarMaterias(materiasActuales);
            }
            Console.WriteLine("Desea eliminar una materia de un estudiante?"+ " digite 1 para si o 2 para no " );

            int eliminar = Convert.ToInt32(Console.ReadLine());
            if ( eliminar == 1)
            {
                Console.WriteLine("Por favor ingresa el nombre del estudiante al que le quieres retirar una materia");
                string nombreEstudiante = Console.ReadLine();

                Estudiante estudiateARetirarMateria = null;
                for (int i = 0; i < estudiantes.Length; i++)
                {
                    if (estudiantes[i].darNombre() == nombreEstudiante)
                    {
                        estudiateARetirarMateria = estudiantes[i];
                    }
                }

                Console.WriteLine("Por favor ingresa el indice del administrador que va a retirar la materia al estudiante " + nombreEstudiante);
                int indiceAdministrativo = Convert.ToInt32(Console.ReadLine());
                Administrativo administrativo = administrativos[indiceAdministrativo];

                Console.WriteLine("Por favor ingresa el codigo de la materia que le quieres eliminar al estudiante " + nombreEstudiante);
                string codigoMateriaEliminar = Console.ReadLine();

                administrativo.retirarAsignatura(estudiateARetirarMateria.darMaterias(), codigoMateriaEliminar);

                Console.WriteLine("Acá se verifica que la materia se haya eliminado");

                for (int i = 0; i < estudiateARetirarMateria.darMaterias().Length; i++)
                {
                    if (estudiateARetirarMateria.darMaterias()[i] != null)
                    {
                        Console.WriteLine("Materia " + i + ": " + estudiateARetirarMateria.darMaterias()[i].darCodigoMateria());
                    }
                    else
                    {
                        Console.WriteLine("La materia " + i + " del estudiante " + nombreEstudiante + " no existe");
                    }
                }

            }

            for (int i=0; i< estudiantes.Length; i++)
            {
                Estudiante estudianteactual = estudiantes[i];
                Console.WriteLine("Datos del estudiante : " + estudianteactual.darNombre());
                Materia[] contenedormaterias = estudianteactual.darMaterias();

                for (int j = 0; j < contenedormaterias.Length; j++)
                {
                    Materia materiaactual = contenedormaterias[j];
                    if(materiaactual!= null)
                    {
                        Console.WriteLine("Datos de la asignatura: Materia " + materiaactual.darnombremateria()+ " codigo: " +materiaactual.darCodigoMateria()+
                            " grupo: "+ materiaactual.dargrupo()+ " en el horario: " + materiaactual.darhorario() + "con el profesor" +materiaactual.darprofesor().darNombre());
                    }
                    
                }
            }

        }
    }
}


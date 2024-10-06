using AutoMapper;
using Core.Services.Class.Dtos;
using Core.Services.Exercise.Dtos;
using Core.Services.Identity.Dtos;
using Core.Services.Member.Dtos;
using Core.Services.Payment.Dtos;
using Core.Services.ProgessTracking.Dtos;
using Core.Services.Trainer.Dtos;
using Core.Services.WorkoutPlan.Dtos;
using Domain.Models;


    public class MapperConfiguration:Profile
    {
        public MapperConfiguration()
        {

            CreateMap<CreateUpdateMemberDto,Member>();
            CreateMap<Member, MemberDto>();

            CreateMap<Trainer, TrainerDto>().ReverseMap();
            CreateMap<Trainer, CreateUpdateTrainerDto>().ReverseMap();

            CreateMap<Exercise, ExerciseDto>().ReverseMap();
            CreateMap<Exercise, CreateUpdateExerciseDto>().ReverseMap();

            CreateMap<ProgressTracking, ProgressTrackingDto>().ReverseMap();
            CreateMap<ProgressTracking, CreateUpdateProgressTrackingDto>().ReverseMap();

            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Payment, CreateUpdatePaymentDto>().ReverseMap();

            CreateMap<WorkoutPlan, WorkoutPlanDto>().ReverseMap();
            CreateMap<WorkoutPlan, CreateUpdateWorkoutPlanDto>().ReverseMap();

            CreateMap<Class, ClassDto>().ReverseMap();
            CreateMap<Class, CreateUpdateClassDto>().ReverseMap();

        CreateMap<RegisterMemberDto, Member>()
        .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }

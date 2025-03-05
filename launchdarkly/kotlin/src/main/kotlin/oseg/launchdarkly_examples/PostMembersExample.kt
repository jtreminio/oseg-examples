package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class PostMembersExample
{
    fun postMembers()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val newMemberForm1 = NewMemberForm(
            email = "sandy@acme.com",
            password = "***",
            firstName = "Ariel",
            lastName = "Flores",
            role = NewMemberForm.Role.reader,
            customRoles = listOf (
                "customRole1",
                "customRole2",
            ),
            teamKeys = listOf (
                "team-1",
                "team-2",
            ),
            roleAttributes = null,
        )

        val newMemberForm = arrayListOf<NewMemberForm>(
            newMemberForm1,
        )

        try
        {
            val response = AccountMembersApi().postMembers(
                newMemberForm = newMemberForm,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AccountMembersApi#postMembers")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AccountMembersApi#postMembers")
            e.printStackTrace()
        }
    }
}

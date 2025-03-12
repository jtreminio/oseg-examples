package oseg.chatwoot_examples

import com.chatwoot.client.infrastructure.*
import com.chatwoot.client.apis.*
import com.chatwoot.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class CreateAnAccountAgentBotExample
{
    fun createAnAccountAgentBot()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"
        // ApiClient.apiKey["agentBotApiKey"] = "AGENT_BOT_API_KEY"
        // ApiClient.apiKey["platformAppApiKey"] = "PLATFORM_APP_API_KEY"

        val agentBotCreateUpdatePayload = AgentBotCreateUpdatePayload(
            name = null,
            description = null,
            outgoingUrl = null,
        )

        try
        {
            val response = AccountAgentBotsApi().createAnAccountAgentBot(
                accountId = null,
                _data = agentBotCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AccountAgentBotsApi#createAnAccountAgentBot")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AccountAgentBotsApi#createAnAccountAgentBot")
            e.printStackTrace()
        }
    }
}
